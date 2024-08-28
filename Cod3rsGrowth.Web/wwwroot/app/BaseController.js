sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History",
	"sap/ui/core/UIComponent",
	"sap/ui/model/json/JSONModel",
	"sap/m/MessageBox",
	"./servico/validacao"
], function (Controller, History, UIComponent, JSONModel, MessageBox, validacao) {
	"use strict";

	return Controller.extend("ui5.cod3rsgrowth.app.BaseController", {
		validacao: validacao,

		getRouter: function () {
			return UIComponent.getRouterFor(this);
		},

		_mensagemDeSucessoAoSalvarEstudio: function (estudio) {
			const mensagemDeSucesso = `Estúdio ${estudio.nome} adicionado com sucesso!`
			MessageBox.success(mensagemDeSucesso, {
				id: "idMessageBoxSucesso",
				styleClass: "sResponsivePaddingClasses",
				dependentOn: this.getView(),
				actions: [MessageBox.Action.OK],
				onClose: (sAction) => {
					if (sAction === MessageBox.Action.OK) {
						this.getRouter().navTo("appEstudio", {}, true);
					}
				}
			})
		},

		requisicaoGet: function (url, nomeDaLista) {
			fetch(url).then(resposta => {
				return resposta.ok
					? resposta.json()
					: resposta.json()
						.then(resposta => { this.validacao.mostrarErroDeValidacao(resposta, this.getView()) });
			})
				.then(resposta => {
					const dataModel = new JSONModel();
					dataModel.setData(resposta);

					this.getView().setModel(dataModel, nomeDaLista);
				});
		},

		requisicaoPost: function (url, estudio) {
			const solicitacaoDeOpcoes = {
				method: 'POST',
				body: JSON.stringify(estudio),
				headers: { "Content-Type": "application/json" }
			}

			fetch(url, solicitacaoDeOpcoes)
				.then(resposta => {
					resposta.ok
						? this._mensagemDeSucessoAoSalvarEstudio(estudio)
						: resposta.json()
							.then(resposta => { this.validacao.mostrarErroDeValidacao(resposta, this.getView()) });
				});
		},

		onNavBack: function () {
			let oHistory, sPreviousHash;

			oHistory = History.getInstance();
			sPreviousHash = oHistory.getPreviousHash();

			if (sPreviousHash !== undefined) {
				window.history.go(-1);
			} else {
				this.getRouter().navTo("appEstudio", {}, true);
			}
		},
	});
});