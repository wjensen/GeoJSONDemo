﻿using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using jGIS.GeoJsonApi.Core.Controllers;
using jGIS.GeoJsonApi.Core.Models;


namespace GeoJSON.RESTApi
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class WebApiApplication : System.Web.HttpApplication
	{
		void ConfigureApi(HttpConfiguration config)
		{
			var unity = new UnityContainer();
			unity.RegisterType<GeoJsonController>();
			unity.RegisterType<IGeoJsonRepository, GeoRSSRepository>("GeoRss");
			unity.RegisterType<IGeoJsonRepository, GeoDatasetRepository>("Geodataset");
			config.DependencyResolver = new IoCContainer(unity);
		}
		protected void Application_Start()
		{
			ConfigureApi(GlobalConfiguration.Configuration);
			AreaRegistration.RegisterAllAreas();

			WebApiConfig.Register(GlobalConfiguration.Configuration);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}
	}
}