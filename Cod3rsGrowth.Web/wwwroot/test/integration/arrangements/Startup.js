sap.ui.define([
    "sap/ui/test/Opa5",
], function (Opa5) {
    "use strict";

    return Opa5.extend("ui5.cod3rsgrowth.test.integration.arrangements.Startup", {
        euInicioMinhaApp: function (parametroOpcoes) {
            const nomeApp = "ui5.cod3rsgrowth";
            var opcoes = parametroOpcoes || {};

            opcoes.delay = opcoes.delay || 1;

            this.iStartMyUIComponent({
                componentConfig: {
                    name: nomeApp,
                    manifest: true
                },
                hash: opcoes.hash,
                autoWait: opcoes.autoWait
            });
        }
    })
});