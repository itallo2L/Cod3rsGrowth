sap.ui.define([
    "sap/ui/test/opaQunit",
    "./AdicionarEstudio"
], (opaTest) => {
    "use strict";

    QUnit.module("Adicionar Estúdio");

    opaTest("Deve carregar a tela de Adicionar Estúdio", function (Given, When, Then) {
        Given.euInicioMinhaApp({
            hash: "/AdicionarEstudio"
        });

        Then
            .naPaginaAdicionarEstudio
            .aTelaDeAdicionarDeveCarregarCorretamente("adicionar");
    });

    opaTest("Deve acusar erro de input com nome vazio", function (Given, When, Then) {
        When
            .naPaginaAdicionarEstudio
            .aoClinarEmSalvarSemDigitarNome("idBotaoSalvarEstudio", "adicionar");

        Then
            .naPaginaAdicionarEstudio
            .aValidacaoDeNomeDoEstudioObrigatorioDeveAparecer("Fechar",
                "A MessageBox com a validação acusando falta de nome no estúdio apareceu.",
                "A MessageBox com a validação acusando falta de nome no estúdio não apareceu.");

        Then
            .naPaginaAdicionarEstudio
            .oInputDeveTerValueStateDeErro("Error");
    });

    opaTest("Deve continuar na página de adicionar ao clicar em Cancelar -> Não", function (Given, When, Then) {
        When
            .naPaginaAdicionarEstudio
            .aoClicarEmCancelar("idBotaoCancelarAdicaoEstudio", "cancelar");

        When
            .naPaginaAdicionarEstudio
            .aoClicarEmNao("Não");

        Then
            .naPaginaAdicionarEstudio
            .aPaginaDevePermanecerNaTelaDeAdicionar("adicionar");
    });

    opaTest("Deve ir para a tela de listagem ao cancelar adição do estúdio", function (Given, When, Then) {
        When
            .naPaginaAdicionarEstudio
            .aoClicarEmCancelarAdicaoDoEstudio("idBotaoCancelarAdicaoEstudio", "cancelar");

        When
            .naPaginaAdicionarEstudio
            .aoClicarEmSim("Sim");

        Then
            .naPaginaListaEstudio
            .aPaginaDeListagemDeveCarregarCorretamente("estudio.Estudio", "listagem");
    });

    opaTest("Deve ir para a tela de adicionar", function (Given, When, Then) {
        When
            .naPaginaListaEstudio
            .aoClicarEmAdicionarEstudio();

        Then
            .naPaginaAdicionarEstudio
            .aPaginaDevePermanecerNaTelaDeAdicionar("adicionar");
    });

    opaTest("Deve adicionar um novo estúdio", function (Given, When, Then) {
        When
            .naPaginaAdicionarEstudio
            .aoDigitarNomeDoEstudio("Estudio Vinte e Seis");

        When
            .naPaginaAdicionarEstudio
            .aoClicarEmSalvar("idBotaoSalvarEstudio", "adicionar");

        When
            .naPaginaAdicionarEstudio
            .aoClicarEmOk("OK");

        Then
            .naPaginaListaEstudio
            .aListaDeveConterVinteESeisEstudios(26);

        Then
            .iTeardownMyApp();
    });
});