sap.ui.define([
    "sap/ui/test/Opa5",
    "../arrangements/Startup",
    "./estudio/JornadaListaEstudio"
], function (Opa5,
    Startup,
    JornadaListaEstudio){
        
    "use strict";

    Opa5.extendConfig({
        arrangements: new Startup(),
        viewNamespace: "ui5.cod3rsgrowth.app.estudio",
        autoWait: true,
        timeout: 15
    });
});