sap.ui.define([
    'sap/ui/test/Opa5',
	'sap/ui/test/matchers/AggregationLengthEquals',
	'sap/ui/test/matchers/I18NText',
    'sap/ui/test/actions/Press'
],
    function (Opa5, AggregationLengthEquals, I18NText, Press) {
        "use strict";

        const viewName = "ui5.cod3rsgrowth.app.estudio.Estudio.view";

        Opa5.createPageObjects({
            naPaginaListaEstudio: {
                actions: {

                },
                assertions: {
                    aTelaFoiCarregadaCorretamente: function () {
                        return this.waitFor({
                            viewName: viewName,
                            success: () => Opa5.assert.ok(true, "A tela de listagem carregou corretamente"),
                            errorMessage: "A tela de listagem não carregou corretamente"
                        });
                    },

                    aListaDeveTerPaginacao: function () {
					return this.waitFor({
						viewName: viewName,
						matchers: new AggregationLengthEquals({
							name: "items",
							length: 20
						}),
						success: function () {
							Opa5.assert.ok(true, "A Lista contém 20 estúdios na primeira página.");
						},
						errorMessage: "A Lista não contém todos os estúdios."
					});
				},

				aPaginaDeveConterTodosOsEstudios: function () {
					return this.waitFor({
						viewName: viewName,
						matchers: new AggregationLengthEquals({
							name: "items",
							length: 25
						}),
						success: function () {
							Opa5.assert.ok(true, "A Lista tem 25 estúdios.");
						},
						errorMessage: "A Lista não contém todos os estúdios."
					});
				},

				oTituloDeveMostrarOTamanhoTotalDeItens: function () {
					return this.waitFor({
						id: "idListaEstudio",
						viewName: viewName,
						matchers: new I18NText({
							key: "worklistTableTitleCount",
							propertyName: "text",
							parameters: [25]
						}),
						success: function () {
							Opa5.assert.ok(true, "O cabeçalho da lista tem 25 estúdios");
						},
						errorMessage: "O cabeçalho da lista não contém o número de estúdios: 25"
					});
				}
                    
            }
        }
    });
});