sap.ui.define([
	"../BaseController"
], function (BaseController) {
	"use strict";
	return BaseController.extend("ui5.cod3rsgrowth.app.notFound.NotFound", {
		onInit: function () {
			let oRouter, oTarget;

			oRouter = this.getRouter();
			oTarget = oRouter.getTarget("notFound");
			oTarget.attachDisplay(function (oEvent) {
				this._oData = oEvent.getParameter("data");
			}, this);
		},

		aoClicarPaginaInicial: function () {
			this.getRouter().navTo("appEstudio", {}, true);
		}
	});
});