document.addEventListener("DOMContentLoaded", function () {
    abrirLoader();
    PopularSelectMarca();
    carregarDadosTabelaVeiculo();
    PopularSelectTipoVeiculo();
    PopularSelectTipoCombustivel();
    $("#hdnModelo").val("0");
    $("#hdnId").val("0");

});

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

async function PopularSelectMarca() {
    const response = await fetch(`../../../cadastro/veiculo/obterTodasMarca`);
    if (response.status != 204) {
        const data = await response.json();
        let options = "<option value='0'>SELECIONE</option>";
        data.map(dado => {
            options += `<option value=${dado.nCodMarca}>${dado.cDescricao}</option>`;
        });

        document.getElementById('selMarca').innerHTML = options;
        document.getElementById('selMarcaAlt').innerHTML = options;
    }
    else
        toastr['error']("Não foi encontrado nenhuma marca cadastrada!", TITULO_TOASTR_ATENCAO);
}

async function PopularSelectModelo(codMarca) {
    const response = await fetch(`../../../cadastro/veiculo/obterTodosModeloxMarca/${codMarca}`);
    if (response.status != 204) {
        const data = await response.json();
        let options = "<option value='0'>SELECIONE</option>";
        data.map(dado => {
            options += `<option value=${dado.nCodModelo}>${dado.cDescricao}</option>`;
        });

        document.getElementById('selModelo').innerHTML = options;
        document.getElementById('selModeloAlt').innerHTML = options;
        $("#selModeloAlt").val($("#hdnModelo").val());
   
    }
    else
        toastr['error']("Não foi encontrado nenhum modelo para essa marca", TITULO_TOASTR_ATENCAO);
}


document.getElementById('selMarca').addEventListener('change', function () {
    if (this.value != null && this.value != "" && this.value != "0")
        PopularSelectModelo(this.value);
});


document.getElementById("btnNovoRegistro").addEventListener("click", function () {
    ModalNovoRegistro();
});

function ModalNovoRegistro() {

    jQuery('#modalNovoRegistro').modal({
        backdrop: 'static',
        keyboard: false
    });
}


async function carregarDadosTabelaVeiculo() {
    const response = await fetch('veiculo/obtertodosporusuario');
    const data = await response.json();
    let tr = '';
    data.map(dado => {
        tr += `<tr>
               <td>${dado.NCodVeiculo}</td>
               <td>${dado.CMarca}</td>
               <td>${dado.CModelo}</td>
               <td>${dado.DAno}</td>
               <td>${dado.CPlaca}</td>
               <td>${dado.CTipoVeiculo}</td>
               <td>${dado.CTipoCombustivel}</td>
               <td>${dado.CQuilometragem}</td>
               <td>
                    <button class="btn btn-icon btn-primary" id="btnAlterarVeiculo${dado.NCodVeiculo}" onclick="AlterarVeiculo(${dado.NCodVeiculo})"><i class="fa fa-edit"></i></button>
                    <button class="btn btn-icon btn-danger" id="btnRemoverVeiculo${dado.NCodVeiculo}" onclick="RemoverVeiculo(${dado.NCodVeiculo})"><i class="fa fa-trash"></i></button>
               </td>
               </tr>`;

    });
    jQuery('#VeiculosCadastrados > tbody').html(tr);
    let nomeTabela = 'VeiculosCadastrados';
    dataTable(nomeTabela);
    fecharLoader();
}

document.getElementById("salvar_veiculo").addEventListener("click", function () {
    NovoVeiculo();
});



function NovoVeiculo() {

    let selmarca = document.getElementById('selMarca').value;
    let selmodelo = document.getElementById('selModelo').value;
    let seltipo = document.getElementById('selTipo').value;
    let selcombustivel = document.getElementById('selCombustivel').value;
    let ano = document.getElementById('txtAno').value;
    let placa = document.getElementById('txtPlaca').value;
    let quilometragem = document.getElementById('txtQuilometragem').value;
    let erros = "";

    if (selmarca == 0 || selmarca == null)
        erros += "Selecione a marca";
    if (selmodelo == 0 || selmodelo == null)
        erros += "</br>Selecione o modelo";
    if (seltipo == 0 || seltipo == null)
        erros += "</br>Selecione o tipo";
    if (selcombustivel == 0 || selcombustivel == null)
        erros += "</br>Selecione o combustível";
    if (ano.length < 4)
        erros += "</br>O ano está incorreto, preencha corretamente!";
    if (quilometragem.length == 0)
        erros += "</br>Preencha a quilometragem!";

    if (erros.length == 0) {

        const dto = {
            NCodMarca: selmarca,
            NCodModelo: selmodelo,
            NCodTipoVeiculo: seltipo,
            NCodTipoCombustivel: selcombustivel,
            DAno: ano,
            CPlaca: placa,
            CQuilometragem: quilometragem
        };

        document.getElementById('salvar_veiculo').disabled = true;

        fetch('../../cadastro/veiculo/adicionar', {
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
                         $("#selMarca").val(0);
                         $("#selModelo").val(0);
                         $("#selTipo").val(0);
                         $("#selCombustivel").val(0);
                         $("#txtAno").val("");
                         $("#txtPlaca").val("");
                         $("#txtQuilometragem").val("");
                    } else {
                        toastr['error'](MSG_ERRO_INSERIR, TITULO_TOASTR_ERRO);
                           }
                    });
          
        document.getElementById('salvar_veiculo').disabled = false;

    }
    else
        toastr['error'](erros, TITULO_TOASTR_ATENCAO);
}


function AtualizaTable() {

    document.getElementById('destroy').innerHTML = "";
    document.getElementById('destroy').innerHTML = `
                    <table class="table table-striped" id="VeiculosCadastrados">
                        <thead>
                            <tr>
                               <th scope="col">#</th>
                               <th scope="col">Marca</th>
                               <th scope="col">Modelo</th>
                               <th scope="col">Ano</th>
                               <th scope="col">Placa</th>
                               <th scope="col">Tipo</th>
                               <th scope="col">Combustível</th>
                               <th scope="col">Quilometragem</th>
                               <th scope="col" style="min-width:80px!important">Opções</th>
                            </tr>
                        </thead>
                        <tbody></tbody>
                    </table>    `;

    carregarDadosTabelaVeiculo();
}


async function AlterarVeiculo(codigo) {

 
    const response = await fetch('veiculo/obterporid/' + codigo);
    const data = await response.json();
    $("#hdnModelo").val(data.NCodModelo);
    PopularSelectModelo(data.NCodMarca);
    $("#selMarcaAlt").val(data.NCodMarca);
    $("#selTipoAlt").val(data.NCodTipoVeiculo);
    $("#selCombustivelAlt").val(data.NCodTipoCombustivel);
    $("#txtAnoAlt").val(data.DAno);
    $("#txtPlacaAlt").val(data.CPlaca);
    $("#txtQuilometragemAlt").val(data.CQuilometragem);
    $("#hdnId").val(data.NCodVeiculo);


    jQuery('#modalAlterarRegistro').modal({
        backdrop: 'static',
        keyboard: false
    });

}

document.getElementById("alterar_veiculo").addEventListener("click", function () {
    AtualizarVeiculo();
});



function AtualizarVeiculo() {

    let selmarca = document.getElementById('selMarcaAlt').value;
    let selmodelo = document.getElementById('selModeloAlt').value;
    let seltipo = document.getElementById('selTipoAlt').value;
    let selcombustivel = document.getElementById('selCombustivelAlt').value;
    let ano = document.getElementById('txtAnoAlt').value;
    let placa = document.getElementById('txtPlacaAlt').value;
    let quilometragem = document.getElementById('txtQuilometragemAlt').value;
    let id = document.getElementById('hdnId').value;
    let erros = "";


    if (id == 0 || id == null)
        erros += "Erro ao obter o registro!";

    if (selmarca == 0 || selmarca == null)
        erros += "Selecione a marca";
    if (id == 0 || id == null)
        erros += "Erro ao encontrar ID!";
    if (selmodelo == 0 || selmodelo == null)
        erros += "</br>Selecione o modelo";
    if (seltipo == 0 || seltipo == null)
        erros += "</br>Selecione o tipo";
    if (selcombustivel == 0 || selcombustivel == null)
        erros += "</br>Selecione o combustível";
    if (ano.length < 4)
        erros += "</br>O ano está incorreto, preencha corretamente!";
    if (quilometragem.length == 0)
        erros += "</br>Preencha a quilometragem!";


    if (erros.length == 0) {

        const dto = {
            NCodMarca: selmarca,
            NCodModelo: selmodelo,
            NCodTipoVeiculo: seltipo,
            NCodTipoCombustivel: selcombustivel,
            DAno: ano,
            CPlaca: placa,
            CQuilometragem: quilometragem,
            NCodVeiculo: id
        };

        document.getElementById('alterar_veiculo').disabled = true;

        fetch('../../cadastro/veiculo/alterar', {
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
                    $("#selMarcaAlt").val(0);
                    $("#selModeloAlt").val(0);
                    $("#selTipoAlt").val(0);
                    $("#selCombustivelAlt").val(0);
                    $("#txtAnoAlt").val("");
                    $("#txtPlacaAlt").val("");
                    $("#txtQuilometragemAlt").val("");
                    $("#hdnModelo").val("0");
                    $("#hdnId").val("0");
                    jQuery('#modalAlterarRegistro').modal('hide');
                } else {
                    toastr['error'](MSG_ERRO_ATUALIZAR, TITULO_TOASTR_ERRO);
                }
            });

        document.getElementById('alterar_veiculo').disabled = false;

    }
    else
        toastr['error'](erros, TITULO_TOASTR_ATENCAO);
}



function RemoverVeiculo(id) {

    jQuery('#modalConfirmarExclusaoVeiculo').modal({
        backdrop: 'static',
        keyboard: false
    }).one('click', '#delete_veiculo', function (e) {

        fetch('../../cadastro/veiculo/remover', {
            method: 'post',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(id)
        }).then(res => res.json())
            .then(res => {

                if (res == 1) {

                    jQuery('#modalConfirmarExclusaoVeiculo').modal('hide');
                    AtualizaTable();
                    toastr['success'](MSG_EXCLUIDO, TITULO_TOASTR_SUCESSO);

                }
                else {
                    jQuery('#modalConfirmarExclusaoVeiculo').modal('hide');
                    toastr['error'](MSG_ERRO_EXCLUIR, TITULO_TOASTR_ERRO);
                }
            });

    });

}


// bloqueando caracteres especiais
$('#txtPlaca').on('keypress', function (event) {
    var regex = new RegExp("^[a-zA-Z0-9]+$");
    var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
    if (!regex.test(key)) {
        event.preventDefault();
        return false;
    }
});