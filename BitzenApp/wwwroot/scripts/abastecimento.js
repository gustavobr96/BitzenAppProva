document.addEventListener("DOMContentLoaded", function () {
    abrirLoader();
    carregarDadosTabelaAbastecimento();
    PopularSelectVeiculo();
    PopularSelectTipoVeiculo();
    PopularSelectTipoCombustivel();
    PopularSelectPosto();
    $("#hdnId").val("0");
});


async function AlterarAbastecimento(codigo) {

    const response = await fetch('abastecimento/obterporid/' + codigo);
    const data = await response.json();
    var date = data.DAbastecimento.split(' ');

    $("#selVeiculoAlt").val(data.NCodVeiculo);
    $("#selPostoAlt").val(data.NCodPosto);
    $("#selCombustivelAlt").val(data.NCodTipoCombustivel);
    $("#selTipoAlt").val(data.NCodTipoVeiculo);
    $("#dtAbastecimentoAlt").val(converterPadraoDataEUA(date[0]));
    $("#txtKMAlt").val(data.NKmAbastecimento);
    $("#txtLitroAlt").val(data.NLitroAbastecimento);
    $("#txtValorAlt").val(data.VVlrPago);
    $("#hdnId").val(data.NCodAbastecimento);


    jQuery('#modalAlterarRegistro').modal({
        backdrop: 'static',
        keyboard: false
    });

}

document.getElementById("atualizar_abastecimento").addEventListener("click", function () {
    AtualizarAbastecimento();
});


function AtualizarAbastecimento() {

    let selveiculo = document.getElementById('selVeiculoAlt').value;
    let selposto = document.getElementById('selPostoAlt').value;
    let seltipo = document.getElementById('selTipoAlt').value;
    let selcombustivel = document.getElementById('selCombustivelAlt').value;
    let data = document.getElementById('dtAbastecimentoAlt').value;
    let km = document.getElementById('txtKMAlt').value;
    let litro = document.getElementById('txtLitroAlt').value;
    let valor = document.getElementById('txtValorAlt').value;
    let id = document.getElementById('hdnId').value;


    let erros = "";

    if (selveiculo == 0 || selveiculo == null)
        erros += "Selecione um veículo";
    if (selposto == 0 || selposto == null)
        erros += "</br>Selecione um posto";
    if (seltipo == 0 || seltipo == null)
        erros += "</br>Selecione o tipo";
    if (selcombustivel == 0 || selcombustivel == null)
        erros += "</br>Selecione o combustível";
    if (data == null)
        erros += "</br>Preencha corretamente a data!";
    if (litro.length == 0 || km == 0)
        erros += "</br>Informe a quantidade de litro abastecido";
    if (km.length == 0 || km == 0)
        erros += "</br>Informe a quantidade de KM abastecido";
    if (valor.length == 0 || valor == 0)
        erros += "</br>Informe o valor";

    if (erros.length == 0) {

        const dto = {
            NCodAbastecimento: id,
            NCodVeiculo: selveiculo,
            NCodPosto: selposto,
            NCodTipoVeiculo: seltipo,
            NCodTipoCombustivel: selcombustivel,
            DAbastecimento: data,
            NKmAbastecimento: km,
            NLitroAbastecimento: litro,
            VVlrPago: valor
        };

        document.getElementById('atualizar_abastecimento').disabled = true;

        fetch('../../cadastro/abastecimento/alterar', {
            method: 'post',
            headers: {
                'Accept': 'application/json, text/plain, */*',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(dto)
        }).then(res => res.json())
            .then(res => {
                if (res == -1) {
                    toastr['error'](MSG_REGISTRO_DUPLICADO, TITULO_TOASTR_ERRO);
                }
                else if (res >= 1) {
                    toastr['success'](MSG_ATUALIZADO, TITULO_TOASTR_SUCESSO);
                    AtualizaTable();
                    jQuery('#modalNovoRegistro').modal('hide');
                    $("#selVeiculoAlt").val(0);
                    $("#selPostoAlt").val(0);
                    $("#selTipoAlt").val(0);
                    $("#selCombustivelAlt").val(0);
                    $("#dtAbastecimentoAlt").val(null);
                    $("#txtKMAlt").val("");
                    $("#txtLitroAlt").val("");
                    $("#txtValorAlt").val("");
                    $("#hdnId").val(0);
                    jQuery('#modalAlterarRegistro').modal('hide');
                } else {
                    toastr['error'](MSG_ERRO_ATUALIZAR, TITULO_TOASTR_ERRO);
                }
            });

        document.getElementById('atualizar_abastecimento').disabled = false;

    }
    else
        toastr['error'](erros, TITULO_TOASTR_ATENCAO);
}



async function PopularSelectPosto() {
    const response = await fetch(`../../../cadastro/abastecimento/obterTodosPosto`);
    if (response.status != 204) {
        const data = await response.json();
        let options = "<option value='0'>SELECIONE</option>";
        data.map(dado => {
            options += `<option value=${dado.nCodPosto}>${dado.cDescricao}</option>`;
        });

        document.getElementById('selPosto').innerHTML = options;
        document.getElementById('selPostoAlt').innerHTML = options;
    }
    else
        toastr['error']("Não foi encontrado nenhum posto!", TITULO_TOASTR_ATENCAO);
}

async function PopularSelectVeiculo() {
    const response = await fetch(`../../../cadastro/veiculo/obtertodosporusuario`);
    if (response.status != 204) {
        const data = await response.json();
        let options = "<option value='0'>SELECIONE</option>";
        data.map(dado => {
            options += `<option value=${dado.NCodVeiculo}>${dado.CPlaca}</option>`;
        });

        document.getElementById('selVeiculo').innerHTML = options;
        document.getElementById('selVeiculoAlt').innerHTML = options;
    }
    else
        toastr['error']("Não foi encontrado nenhum veículo!", TITULO_TOASTR_ATENCAO);
}

async function PopularSelectTipoVeiculo() {
    const response = await fetch(`../../../cadastro/veiculo/obterTodosTipoVeiculo`);
    if (response.status != 204) {
        const data = await response.json();
        let options = "<option value='0'>SELECIONE</option>";
        data.map(dado => {
            options += `<option value=${dado.nCodTipoVeiculo}>${dado.cDescricao}</option>`;
        });

        document.getElementById('selTipo').innerHTML = options;
        document.getElementById('selTipoAlt').innerHTML = options;
    }
    else
        toastr['error']("Não foi encontrado nenhum tipo de veículo!", TITULO_TOASTR_ATENCAO);
}

async function PopularSelectTipoCombustivel() {
    const response = await fetch(`../../../cadastro/veiculo/obterTodosTipoCombustivel`);
    if (response.status != 204) {
        const data = await response.json();
        let options = "<option value='0'>SELECIONE</option>";
        data.map(dado => {
            options += `<option value=${dado.nCodCombustivel}>${dado.cDescricao}</option>`;
        });

        document.getElementById('selCombustivel').innerHTML = options;
        document.getElementById('selCombustivelAlt').innerHTML = options;
    }
    else
        toastr['error']("Não foi encontrado nenhum tipo de combustivel", TITULO_TOASTR_ATENCAO);
}

document.getElementById("btnNovoRegistro").addEventListener("click", function () {
    ModalNovoRegistro();
});

function ModalNovoRegistro() {

    jQuery('#modalNovoRegistro').modal({
        backdrop: 'static',
        keyboard: false
    });
}



async function carregarDadosTabelaAbastecimento() {
    const response = await fetch('abastecimento/obtertodosporusuario');
    const data = await response.json();
    let tr = '';
    var date;
    data.map(dado => {
        date = dado.DAbastecimento.split(' ');
        tr += `<tr>
               <td>${dado.NCodAbastecimento}</td>
               <td>${dado.NKmAbastecimento}</td>
               <td>${dado.NLitroAbastecimento}</td>
               <td>${dado.VVlrPago}</td>
               <td>${date[0]}</td>
               <td>${dado.Posto}</td>
               <td>${dado.TipoCombustivel}</td>
               <td>${dado.TipoVeiculo}</td>
               <td>${dado.CPlaca}</td>
               <td>
                    <button class="btn btn-icon btn-primary" id="btnAlterarAbastecimento${dado.NCodAbastecimento}" onclick="AlterarAbastecimento(${dado.NCodAbastecimento})"><i class="fa fa-edit"></i></button>
                    <button class="btn btn-icon btn-danger" id="btnRemoverAbasteciento${dado.NCodAbastecimento}" onclick="RemoverAbastecimento(${dado.NCodAbastecimento})"><i class="fa fa-trash"></i></button>
               </td>
               </tr>`;

    });
    jQuery('#AbastecimentosCadastrados > tbody').html(tr);
    let nomeTabela = 'AbastecimentosCadastrados';
    dataTable(nomeTabela);
    fecharLoader();
}


document.getElementById("salvar_abastecimento").addEventListener("click", function () {
    NovoAbastecimento();
});



function NovoAbastecimento() {

    let selveiculo = document.getElementById('selVeiculo').value;
    let selposto = document.getElementById('selPosto').value;
    let seltipo = document.getElementById('selTipo').value;
    let selcombustivel = document.getElementById('selCombustivel').value;
    let data = document.getElementById('dtAbastecimento').value;
    let km = document.getElementById('txtKM').value;
    let litro = document.getElementById('txtLitro').value;
    let valor = document.getElementById('txtValor').value;


    let erros = "";

    if (selveiculo == 0 || selveiculo == null)
        erros += "Selecione um veículo";
    if (selposto == 0 || selposto == null)
        erros += "</br>Selecione um posto";
    if (seltipo == 0 || seltipo == null)
        erros += "</br>Selecione o tipo";
    if (selcombustivel == 0 || selcombustivel == null)
        erros += "</br>Selecione o combustível";
    if (data == null)
        erros += "</br>Preencha corretamente a data!";
    if (litro.length == 0 || km == 0)
        erros += "</br>Informe a quantidade de litro abastecido";
    if (km.length == 0 || km == 0)
        erros += "</br>Informe a quantidade de KM abastecido";
    if (valor.length == 0 || valor == 0)
        erros += "</br>Informe o valor";

    if (erros.length == 0) {

        const dto = {
            NCodVeiculo: selveiculo,
            NCodPosto: selposto,
            NCodTipoVeiculo: seltipo,
            NCodTipoCombustivel: selcombustivel,
            DAbastecimento: data,
            NKmAbastecimento: km,
            NLitroAbastecimento: litro,
            VVlrPago: valor
        };

        document.getElementById('salvar_abastecimento').disabled = true;

        fetch('../../cadastro/abastecimento/adicionar', {
            method: 'post',
            headers: {
                'Accept': 'application/json, text/plain, */*',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(dto)
        }).then(res => res.json())
            .then(res => {
                if (res == -1) {
                    toastr['error'](MSG_REGISTRO_DUPLICADO, TITULO_TOASTR_ERRO);
                }
                else if (res >= 1) {
                    toastr['success'](MSG_SUCESSO, TITULO_TOASTR_SUCESSO);
                    AtualizaTable();
                    jQuery('#modalNovoRegistro').modal('hide');
                    $("#selVeiculo").val(0);
                    $("#selPosto").val(0);
                    $("#selTipo").val(0);
                    $("#selCombustivel").val(0);
                    $("#dtAbastecimento").val(null);
                    $("#txtKM").val("");
                    $("#txtLitro").val("");
                    $("#txtValor").val("");
                   
                } else {
                    toastr['error'](MSG_ERRO_INSERIR, TITULO_TOASTR_ERRO);
                }
            });

        document.getElementById('salvar_abastecimento').disabled = false;

    }
    else
        toastr['error'](erros, TITULO_TOASTR_ATENCAO);
}



function RemoverAbastecimento(id) {

    jQuery('#modalConfirmarExclusaoAbastecimento').modal({
        backdrop: 'static',
        keyboard: false
    }).one('click', '#delete_abastecimento', function (e) {

        fetch('../../cadastro/abastecimento/remover', {
            method: 'post',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(id)
        }).then(res => res.json())
            .then(res => {

                if (res == 1) {

                    jQuery('#modalConfirmarExclusaoAbastecimento').modal('hide');
                    AtualizaTable();
                    toastr['success'](MSG_EXCLUIDO, TITULO_TOASTR_SUCESSO);

                }
                else {
                    jQuery('#modalConfirmarExclusaoAbastecimento').modal('hide');
                    toastr['error'](MSG_ERRO_EXCLUIR, TITULO_TOASTR_ERRO);
                }
            });

    });

}

function AtualizaTable() {

    document.getElementById('destroy').innerHTML = "";
    document.getElementById('destroy').innerHTML = `
                    <table class="table table-striped" id="AbastecimentosCadastrados">
                        <thead>
                            <tr>
                                <th scope="col">#</th>
                                <th scope="col">KM Abastecimento</th>
                                <th scope="col">Litros Abast/</th>
                                <th scope="col">Valor Pago</th>
                                <th scope="col">Data Abastecimento</th>
                                <th scope="col">Posto</th>
                                <th scope="col">Combustível</th>
                                <th scope="col">Tipo</th>
                                <th scope="col">Placa Veículo</th>
                                <th scope="col" style="min-width:80px!important">Opções</th>
                            </tr>
                        </thead>
                        <tbody></tbody>
                    </table>    `;

    carregarDadosTabelaAbastecimento();
}

