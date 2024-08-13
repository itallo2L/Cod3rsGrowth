QUnit.config.autostart = false;

sap.ui.require(
    [
        "sap/ui/core/Core",
        "ui5/cod3rsgrowth/test/integration/pages/AllJourneys"
    ],
    async function (Core, ComponentContainer) {
        "use strict";

		await Core.ready();

        QUnit.start();
    }
);