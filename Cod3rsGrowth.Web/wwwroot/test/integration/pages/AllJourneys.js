sap.ui.define([
    "sap/ui/test/Opa5",
    "../arrangements/Startup",
    "./pages/estudio/JornadaLista"
], function (Opa5,
    Startup,
    JornadaLista){
        
    "use strict";

    Opa5.extendConfig({
        arrangements: new Startup(),
        viewNamespace: "",
        autoWait: true,
        timeout: 15
    });
});