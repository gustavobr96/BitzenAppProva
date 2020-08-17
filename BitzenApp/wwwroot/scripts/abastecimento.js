document.addEventListener("DOMContentLoaded", function () {
    abrirLoader();
    carregarDadosTabelaAbastecimento();
    PopularSelectVeiculo();
    PopularSelectTipoVeiculo();
    PopularSelectTipoCombustivel();
    PopularSelectPosto();
});


async function PopularSelectPosto() {
    const response = await fetch(`../../../cadastro/abastecimento/obterTodosPosto`);
    if (response.status != 204) {
        const data = await response.json();
        let options = "<option value='0'>SELECIONE</option>";
        data.map(dado => {
            options += `<option value=${dado.nCodPosto}>${dado.cDescricao}</option>`;
        });

        document.getElementById('selPosto').innerHTML = options;
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
    data.map(dado => {
        tr += `<tr>
               <td>${dado.NCodAbastecimento}</td>
               <td>${dado.NKmAbastecimento}</td>
               <td>${dado.NLitroAbastecimento}</td>
               <td>${dado.VVlrPago}</td>
               <td>${dado.DAbastecimento}</td>
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