sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History",
	"sap/ui/core/UIComponent",
	"sap/ui/model/json/JSONModel",
	"sap/m/MessageBox"
], function (Controller, History, UIComponent, JSONModel, MessageBox) {
	"use strict";

	return Controller.extend("ui5.cod3rsgrowth.app.BaseController", {

		getRouter: function () {
			return UIComponent.getRouterFor(this);
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

		_requisicaoGet: function (url, nomeDaLista) {
			fetch(url).then(resposta => {
				return resposta.ok
					? resposta.json()
					: resposta.json()
						.then(resposta => { this._mostrarErroDeValidacao(resposta) });
			})
				.then(resposta => {
					const dataModel = new JSONModel();
					dataModel.setData(resposta);

					this.getView().setModel(dataModel, nomeDaLista);
				});
		},

		_requisicaoPost: function (url, estudio) {
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
							.then(resposta => { this._mostrarErroDeValidacao(resposta) });
				});
		},

		_mensagemDeSucessoAoSalvarEstudio : function (estudio) {
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

		_mostrarErroDeValidacao: function (erro) {
			const erroDeValidacao = "Erro de validação"
			const tituloMensagem = "Erro";
			const detalhesMensagem = "Detalhes:";
			const statusMensagem = "Status:"

			if (erro.Title === erroDeValidacao) {
				const mensagensDeErro = Object.values(erro.Extensions.ErroDeValidacao).join("\r \n");

				MessageBox.error(`${erro.Title} \n \n ${mensagensDeErro}`, {
					title: tituloMensagem,
					id: "idMessageBoxErroValidacao",
					details:
						`<p><strong>${statusMensagem} ${erro.Status}</strong></p>` +
						`<p><strong> ${detalhesMensagem} </strong></p>` +
						"<ul>" +
						`<li>${erro.Detail}</li>` +
						"</ul>",
					styleClass: "sResponsivePaddingClasses",
					dependentOn: this.getView()
				});
			} else {
				MessageBox.error(`${erro.Title}`, {
					title: tituloMensagem,
					id: "idMessageBoxErro",
					details:
						`<p><strong>${statusMensagem} ${erro.Status}</strong></p>` +
						`<p><strong> ${detalhesMensagem} </strong></p>` +
						"<ul>" +
						`<li>${erro.Detail}</li>` +
						"</ul>",
					styleClass: "sResponsivePaddingClasses",
					dependentOn: this.getView()
				});
			}
		}
	});
});