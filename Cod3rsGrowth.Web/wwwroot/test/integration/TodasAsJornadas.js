sap.ui.define([
    'sap/ui/test/Opa5',
    './arrangements/Startup',
    './pages/JornadaEstudio',
    './pages/JornadaAdicionarEstudio',
    './pages/JornadaDetalhesEstudio'
], function (Opa5, Startup, JornadaEstudio, JornadaAdicionarEstudio, DetalhesEstudio) {
    'use strict';

    Opa5.extendConfig({
        arrangements: new Startup(),
        viewNamespace: "ui5.cod3rsgrowth.app",
        autoWait: true
    });
});