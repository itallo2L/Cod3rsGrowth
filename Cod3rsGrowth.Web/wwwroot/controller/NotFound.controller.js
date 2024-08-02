sap.ui.define([
    "./BaseController"
 ], function (BaseController) {
    "use strict";
    return BaseController.extend("ui5.cod3rsgrowth.controller.NotFound", {
       onInit: function () {
         var oRouter, oTarget;

			oRouter = this.getRouter();
			oTarget = oRouter.getTarget("notFound");
			oTarget.attachDisplay(function (oEvent) {
				this._oData = oEvent.getParameter("data");
			}, this);
		}
    });
 });