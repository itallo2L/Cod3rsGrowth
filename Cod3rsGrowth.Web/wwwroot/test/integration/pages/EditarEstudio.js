sap.ui.define([
    'sap/ui/test/Opa5',
    'sap/ui/test/matchers/PropertyStrictEquals',
    'sap/ui/test/actions/Press'
],
    function (Opa5, PropertyStrictEquals, Press) {
        "use strict";

        const telaDeEditar = "adicionarEstudio.AdicionarEstudio";

        Opa5.createPageObjects({
            naPaginaEditarEstudio: {
                actions: {

                    aoclicarEmEditar: function (tipo, texto, mensagemDeSucesso, mensagemFracasso) {
                        this._metodoTeste(tipo, texto, mensagemDeSucesso, mensagemFracasso);
                    },

                    _metodoTeste: function (tipo, texto, mensagemDeSucesso, mensagemFracasso) {
                        return this.waitFor({
                            viewName: telaDeEditar,
                            controlType: tipo,
                            matchers: new PropertyStrictEquals({
                                name: "text",
                                value: texto
                            }),
                            success: () => Opa5.assert.ok(true, mensagemDeSucesso),
                            errorMessage: mensagemFracasso
                        });
                    }
                },
                assertions: {
                    aPaginaDeEditarDeveCarregarCorretamente: function () {
                        return this.waitFor({
                            viewName: telaDeEditar,
                            success: () => Opa5.assert.ok(true, `A tela de editar carregou corretamente.`),
                            errorMessage: `A tela de editar não carregou corretamente`
                        });
                    },
                }
            }
        });
    });