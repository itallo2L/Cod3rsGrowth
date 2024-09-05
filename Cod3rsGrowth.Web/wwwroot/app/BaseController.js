sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History",
	"sap/ui/core/UIComponent",
	"sap/ui/model/json/JSONModel",
	"sap/m/MessageBox",
	"./servico/validacao",
	"sap/m/Dialog",
	"sap/m/Button",
	"sap/m/library",
	"sap/m/Text",
	"sap/ui/core/library",
], function (Controller, History, UIComponent, JSONModel, MessageBox, validacao, Dialog, Button, mobileLibrary, Text, coreLibrary) {
	"use strict";

	var idDetalhesEstudio;
	var nomeDeletarEstudio;
	return Controller.extend("ui5.cod3rsgrowth.app.BaseController", {
		validacao: validacao,

		getRouter: function () {
			return UIComponent.getRouterFor(this);
		},

		_mensagemDeSucesso: function (mensagem, idEstudio) {
			debugger
			MessageBox.success(mensagem, {
				id: "idMessageBoxSucesso",
				styleClass: "sResponsivePaddingClasses",
				dependentOn: this.getView(),
				actions: [MessageBox.Action.OK],
				onClose: (sAction) => {
					if (sAction === MessageBox.Action.OK) {
						idEstudio
							? this.getRouter().navTo("appDetalhesEstudio", { estudioId: idEstudio }, true)
							: this.getRouter().navTo("appEstudio", {}, true);
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

		requisicaoDelete: function (url, estudio) {
			const solicitacaoDeOpcoes = {
				method: "DELETE",
			}

			let mensagemDeSucesso = `Estúdio "${estudio}" deletado com sucesso!`
			fetch(url, solicitacaoDeOpcoes)
				.then(resposta => {
					resposta.ok
						? this._mensagemDeSucesso(mensagemDeSucesso)
						: resposta.json()
							.then(resposta => { this.validacao.mostrarErroDeValidacao(resposta, this.getView()) });
				});
		},

		requisicaoPostOuPatch: function (tipoDaRequisicao, url, estudio, mensagem, idEstudio) {
			const solicitacaoDeOpcoes = {
				method: tipoDaRequisicao,
				body: JSON.stringify(estudio),
				headers: { "Content-Type": "application/json" }
			}

			let mensagemDeSucesso = `Estúdio "${estudio.nome}" ${mensagem} com sucesso!`

			fetch(url, solicitacaoDeOpcoes)
				.then(resposta => {
					resposta.ok
						? this._mensagemDeSucesso(mensagemDeSucesso, idEstudio)
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

		mensagemAoCancelarAdicaoOuEdicao: function (mensagem, idEstudio) {
			idEstudio
				? idEstudio = parseInt(idEstudio)
				: idEstudio

			this._mensagemDeAviso(mensagem, idEstudio);
		},

		mensagemAoCancelarRemocao: function (mensagem, nomeEstudio, urlObterPorId) {
			this._mensagemDeAviso(mensagem, nomeEstudio, urlObterPorId);
		},

		_mensagemDeAviso: function (mensagem, chave, urlObterPorId) {
			this.aMensagemDeCancelarEstudio = new Dialog({
				type: mobileLibrary.DialogType.Message,
				title: "Aviso",
				state: coreLibrary.ValueState.Warning,
				content: new Text({ text: mensagem }),
				beginButton: new Button({
					type: mobileLibrary.ButtonType.Negative,
					text: "Sim",
					press: function () {
						if (chave == parseInt(chave)) {
							idDetalhesEstudio = chave;
							this.aMensagemDeCancelarEstudio.close();
							this.getRouter().navTo("appDetalhesEstudio", { estudioId: idDetalhesEstudio }, true);
						} else if (chave) {
							nomeDeletarEstudio = chave;
							this.requisicaoDelete(urlObterPorId, nomeDeletarEstudio);
							this.aMensagemDeCancelarEstudio.close();
							this.getRouter().navTo("appEstudio", {}, true);
						} else {
							this.getRouter().navTo("appEstudio", {}, true);
						}
					}.bind(this)
				}),
				endButton: new Button({
					type: mobileLibrary.ButtonType.Success,
					text: "Não",
					press: function () {
						this.aMensagemDeCancelarEstudio.close();
					}.bind(this)
				})
			});
			this.aMensagemDeCancelarEstudio.open();
		}
	});
});