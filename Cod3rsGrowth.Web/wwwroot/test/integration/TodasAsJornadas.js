sap.ui.define([
    'sap/ui/test/Opa5',
    './arrangements/Startup',
    './pages/JornadaEstudio',
    './pages/JornadaAdicionarEstudio',
    './pages/JornadaDetalhesEstudio',
    './pages/JornadaEditarEstudio',
    './pages/JornadaDeletarEstudio',
], function (Opa5, Startup, JornadaEstudio, JornadaAdicionarEstudio, DetalhesEstudio, JornadaEditarEstudio, JornadaDeletarEstudio) {
    'use strict';

    Opa5.extendConfig({
        arrangements: new Startup(),
        viewNamespace: "ui5.cod3rsgrowth.app",
        autoWait: true
    });
});