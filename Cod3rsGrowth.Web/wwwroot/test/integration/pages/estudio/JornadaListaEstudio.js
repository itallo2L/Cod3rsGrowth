sap.ui.define([
    "sap/ui/test/opaQunit",
    "./ListaEstudio"
], function (opaQunit,
    ListaEstudio) {
        "use strict";
    opaQunit.module("ListaEstudio", () => {

        opaTest("Deve exibir a tela de listagm do Estúdio", function (Given, When, Then) {
            Given.iStartMyApp({
                hash: "/#/estudio"
            });

            Then
                .naPaginaDeListaEstudio
                .aTelaFoiCarregadaCorretamente();
        });
    });
});