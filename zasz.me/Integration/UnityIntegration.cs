﻿using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using Microsoft.Practices.Unity;
using zasz.me.Areas.Pro.Controllers;
using zasz.me.Configuration;

namespace zasz.me.Integration
{
    public class UnityIntegration
    {
        public static void Bootstrap()
        {
            var BigBox = new UnityContainer();
            Config.Unity.Configure(BigBox, "BigBox");
            Config.PutConfigurationAndSettingsInside(BigBox);
            HugeBox.Swallow(BigBox);
            ControllerBuilder.Current.SetControllerFactory(new UnityControllerBuilder());
        }
    }

    public class UnityControllerBuilder : IControllerFactory
    {
        private readonly UnityContainer _BigBox;

        public UnityControllerBuilder()
        {
            _BigBox = HugeBox.BigBox;
        }

        #region IControllerFactory Members

        public IController CreateController(RequestContext RequestContext, string ControllerName)
        {
            try
            {
                var AreaName = (string)RequestContext.RouteData.DataTokens["area"];
                ControllerName = String.Format("zasz.me.Areas.{0}.Controllers.{1}Controller", AreaName, ControllerName);
                if (String.IsNullOrWhiteSpace(ControllerName)) throw new ArgumentException("Controller name was NULL");
                var ControllerType = Type.GetType(ControllerName);

                if (null == ControllerType) throw new ArgumentException("Controller type not found : " + ControllerName);
                if (!(typeof(IController).IsAssignableFrom(ControllerType))) throw new ArgumentException("The type requested is not a controller : " + ControllerName);
                var Controller = _BigBox.Resolve(Type.GetType(ControllerName)) as IController;

                if (null == Controller) throw new ArgumentException("Unity could not resolve the controller : " + ControllerName);
                return Controller;
            }
            catch (Exception Error)
            {
                RequestContext.RouteData.DataTokens["OriginalAction"] = RequestContext.RouteData.Values["Action"];
                RequestContext.RouteData.DataTokens["OriginalController"] = RequestContext.RouteData.Values["Controller"];
                RequestContext.RouteData.DataTokens["OriginalError"] = Error;
                RequestContext.RouteData.Values["Action"] = "NotFound";
                RequestContext.RouteData.Values["Controller"] = "Error";
                return _BigBox.Resolve<ErrorController>();
            }
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext RequestContext, string ControllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController Controller)
        {
            _BigBox.Teardown(Controller);
        }

        #endregion
    }


    /// <summary>
    /// This is a Lifetime Manager that maintains a singleton instance per web request. For example
    /// A DB Session can be managed by this manager - you have one session instance for the whole 
    /// Request. 
    /// 
    /// This Q&A is good reference
    /// http://stackoverflow.com/questions/707138/using-asp-net-session-for-lifetime-management-unity
    /// </summary>
    public class SingletonPerRequest : LifetimeManager, IDisposable
    {
        private readonly string _Name;

        #region IDisposable Members

        public void Dispose()
        {
            RemoveValue();
        }

        #endregion

        public SingletonPerRequest(string Name)
        {
            _Name = Name;
        }

        public override object GetValue()
        {
            return HttpContext.Current.Items[_Name];
        }

        /// <summary>
        /// http://www.tavaresstudios.com/Blog/post/Writing-Custom-Lifetime-Managers.aspx says framework never calls the RemoveValue(), 
        /// I suppose its meant for utility xD
        /// </summary>
        public override void RemoveValue()
        {
            HttpContext.Current.Items.Remove(_Name);
        }

        /// <summary>
        /// This method is called by the container only when GetValue returns null, which is once per webrequest.
        /// </summary>
        /// <param name="NewValue">The newly created object that the container constructs and gives to this LifeTimeManager</param>
        public override void SetValue(object NewValue)
        {
            HttpContext.Current.Items[_Name] = NewValue;
        }
    }
}