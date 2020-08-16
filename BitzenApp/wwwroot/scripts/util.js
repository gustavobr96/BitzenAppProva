/**
 * Script responsável por métodos padrões e validações
*/
document.addEventListener("DOMContentLoaded", function () {

    $('input[type=text]').keyup(function () {
        this.value = this.value.toUpperCase();
    });
    $('textarea').keyup(function () {
        this.value = this.value.toUpperCase();
    });
    $('.maskDinheiro').mask("#.##0,00", { reverse: true });
    $('.maskData').mask('00/00/0000');
    $('.maskTelefone').mask('(99) 999999999');
    $('.maskTel').mask('0000-00009');
    $('.maskDdd').mask('99');
    $('.maskCnpj').mask('00.000.000/0000-00');
    $('.maskCpf').mask('000.000.000-00');
    $('.maskCep').mask('00000-000');
    $('.maskMesAno').mask('00/0000');



});

function Alerta(divId, msg) {
    $("#" + divId).html(msg);
    $("#" + divId).show(300);
    $("#" + divId).delay(3000);
    $("#" + divId).hide(300);
};

function DataAtual() {

    let today = new Date();
    let dd = today.getDate();

    let mm = today.getMonth() + 1;
    const yyyy = today.getFullYear();
    if (dd < 10) {
        dd = `0${dd}`;
    }

    if (mm < 10) {
        mm = `0${mm}`;
    }
    today = `${dd}/${mm}/${yyyy}`;

    return today;
}


function validaData(data) {
    reg = /[^\d\/\.]/gi;                  // Mascara = dd/mm/aaaa | dd.mm.aaaa
    let valida = data.replace(reg, '');    // aplica mascara e valida só numeros
    if (valida && valida.length == 10) {  // é válida, então ;)
        let ano = data.substr(6),
            mes = data.substr(3, 2),
            dia = data.substr(0, 2),
            M30 = ['04', '06', '09', '11'],
            v_mes = /(0[1-9])|(1[0-2])/.test(mes),
            v_ano = /(19[1-9]\d)|(20\d\d)|2100/.test(ano),
            rexpr = new RegExp(mes),
            fev29 = ano % 4 ? 28 : 29;

        if (v_mes && v_ano) {
            if (mes == '02') return (dia >= 1 && dia <= fev29);
            else if (rexpr.test(M30)) return /((0[1-9])|([1-2]\d)|30)/.test(dia);
            else return /((0[1-9])|([1-2]\d)|3[0-1])/.test(dia);
        }
    }
    return false
}



// foi criado este método para conseguir atualizar o datatable
// primeiro destroi o datatable e depois cria outro novo.
function destruirDataTable(nomeTabela) {

    if ($.fn.dataTable.isDataTable(`#${nomeTabela}`)) {
        $(`#${nomeTabela}`).DataTable().destroy();
    }
}

function dataTable(nomeTabela, valida = 0, ordenacao = 'desc') {

    $(`#${nomeTabela}`).on('prepreInit.dt').DataTable({
        "language": {
            "lengthMenu": "Mostrar _MENU_ registros por página",
            "zeroRecords": "Não foram encontrados registros",
            "searchPlaceholder": "Buscar registros",
            "info": "Mostrando registros de _START_ ao _END_ de um total de  _TOTAL_ registros",
            "infoEmpty": "Não existem registros",
            "infoFiltered": "(filtrado de um total de _MAX_ registros)",
            "search": "Buscar:",
            "paginate": {
                "first": "Primero",
                "last": "Último",
                "next": "Próximo",
                "previous": "Anterior"
            },

        },
        "iDisplayLength": 8,
        "bDestroy": true,
        "order":[[valida,ordenacao],[0,'asc']],
        "initComplete": fecharLoader()

    });


}

function validarEmail(field) {

    let emailInvalido = false;
    let usuario = "";
    let dominio = "";

    if (field != null || field != '') {

        usuario = field.value.substring(0, field.value.indexOf("@"));
        dominio = field.value.substring(field.value.indexOf("@") + 1, field.value.length);


        if ((usuario.length >= 1) &&
            (dominio.length >= 3) &&
            (usuario.search("@") == -1) &&
            (dominio.search("@") == -1) &&
            (usuario.search(" ") == -1) &&
            (dominio.search(" ") == -1) &&
            (dominio.search(".") != -1) &&
            (dominio.indexOf(".") >= 1) &&
            (dominio.lastIndexOf(".") < dominio.length - 1)) {

            emailInvalido = false;
        }
        else {
            emailInvalido = true;
        }
    }

    return emailInvalido;
}

function converterPadraoDataBr(dt) {
    if (dt != null && dt != "") {
        dt = dt.split('-');
        let data = dt[2] + '/' + dt[1] + '/' + dt[0];
        return data;
    }
    return "";
}

function converterPadraoDataEUA(dt) {
    let data = "";
    if (dt != null && dt != "") {
        dt = dt.split('/');
        data = dt[2] + '-' + dt[1] + '-' + dt[0];
    }
    return data;
}

function abrirLoader() {
    $('#divLoader').modal('show');
}

function fecharLoader() {
    setTimeout(function () {
        $('#divLoader').modal('hide');
    }, 500);
}

function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : evt.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;
    return true;
}