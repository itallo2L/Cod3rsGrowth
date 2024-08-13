sap.ui.define([
    'sap/ui/test/Opa5'
],
    function (Opa5) {
        "use strict";

        const viewName = "ui5.cod3rsgrowth.app.estudio.Estudio";

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
                        })
                    }
                }
            }
        });
    });