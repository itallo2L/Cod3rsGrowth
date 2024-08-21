sap.ui.define([
    "../BaseController",
    "sap/ui/core/library",
	"sap/m/Dialog",
	"sap/m/Button",
	"sap/m/library",
	"sap/m/Text",
    "sap/m/MessageToast"
], (BaseController, coreLibrary, Dialog, Button, mobileLibrary, Text, MessageToast) => {
    "use strict";

    const nomeEsudioVazio = "";
    const idInputEstudio = "idInputEstudio";

    return BaseController.extend("ui5.cod3rsgrowth.app.estudio.AdicionarEstudio", {
        onInit: function () {
        },

        aoClicarSalvarEstudio: function () {
            let entrada = this.getView().byId(idInputEstudio).getValue();
            this._aovalidarEntrada(entrada);
        },

        _aovalidarEntrada: function (entrada) {
            let erro = "Error";
            let sucesso = "None";

            if(entrada === nomeEsudioVazio)
                this.getView().byId(idInputEstudio).setValueState(erro);
            else
                this.getView().byId(idInputEstudio).setValueState(sucesso)
        },

        aoClicarCancelarEstudio: function () {
            if (!this.aMensagemDeCancelarEstudio) {
				this.aMensagemDeCancelarEstudio = new Dialog({
					type: mobileLibrary.DialogType.Message,
					title: "Aviso",
					state: coreLibrary.ValueState.Warning,
					content: new Text({ text: "Tem certeza que deseja cancelar a adição de um novo estúdio?" }),
					beginButton: new Button({
						type: mobileLibrary.ButtonType.Emphasized,
						text: "Sim",
						press: function () {
							this.aMensagemDeCancelarEstudio.close();
                            this.getRouter().navTo("appEstudio", {}, true);
						}.bind(this)
					}),
                    endButton: new Button({
						text: "Não",
						press: function () {
							this.aMensagemDeCancelarEstudio.close();
						}.bind(this)
					})
				});
			}
			this.aMensagemDeCancelarEstudio.open();
        }
    });
});