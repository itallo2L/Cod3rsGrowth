sap.ui.define([
    'sap/ui/test/Opa5',
    'spa/ui/test/actions/EnterText',
    'spa/ui/test/actions/Press',
    'spa/ui/test/matchers/AggregationLengthEquals',
    'spa/ui/test/matchers/PropertyStrictEquals',
    'spa/ui/test/matchers/BidingPath'
],
    function (Opa5,
        EnterText,
        Press,
        AggregationLengthEquals,
        PropertyStrictEquals,
        BidingPath) {
        "use strict";

        let viewName = ".estudio.Lista";

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