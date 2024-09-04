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

		_mensagemDeSucesso: function (mensagem) {
			MessageBox.success(mensagem, {
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

		requisicaoGet: function (url, view, nomeDaLista) {
			fetch(url).then(resposta => {
				return resposta.ok
					? resposta.json()
					: resposta.json()
						.then(resposta => { this.validacao.mostrarErroDeValidacao(resposta, view) });
			})
				.then(resposta => {
					const dataModel = new JSONModel();
					dataModel.setData(resposta);

					this.getView().setModel(dataModel, nomeDaLista);
				});
		},

		requisicaoDelete: function (url, estudio, mensagem) {
			const solicitacaoDeOpcoes = {
				method: "DELETE",
			}

			let mensagemDeSucesso = `Estúdio "${estudio}" ${mensagem} com sucesso!`
			fetch(url, solicitacaoDeOpcoes)
				.then(resposta => {
					resposta.ok
						? this._mensagemDeSucesso(mensagemDeSucesso)
						: resposta.json()
							.then(resposta => { this.validacao.mostrarErroDeValidacao(resposta, this.getView()) });
				});
		},

		requisicaoPostOuPatch: function (tipoDaRequisicao, url, estudio, mensagem) {
			const solicitacaoDeOpcoes = {
				method: tipoDaRequisicao,
				body: JSON.stringify(estudio),
				headers: { "Content-Type": "application/json" }
			}

			let mensagemDeSucesso = `Estúdio "${estudio.nome}" ${mensagem} com sucesso!`

			fetch(url, solicitacaoDeOpcoes)
				.then(resposta => {
					resposta.ok
						? this._mensagemDeSucesso(mensagemDeSucesso)
						: resposta.json()
							.then(resposta => { this.validacao.mostrarErroDeValidacao(resposta, this.getView()) });
				});
		},

		obterEstudioEditar: function (url, view) {
            fetch(url).then(resposta => {
                return resposta.ok
                    ? resposta.json()
                        .then(resposta => { this._colocarValoresNosCampos(resposta) })
                    : resposta.json()
                        .then(resposta => { this.validacao.mostrarErroDeValidacao(resposta, view) })
            });
        },

		onNavBack: function () {
			let oHistory, sPreviousHash;
			
			oHistory = History.getInstance();
			sPreviousHash = oHistory.getPreviousHash();
			
			if (sPreviousHash !== undefined) {
				window.history.go(-1);
			} else {
				let oRouter = this.getOwnerComponent().getRouter();
				oRouter.navTo("appEstudio", {}, true);
			}
		},
	});
});