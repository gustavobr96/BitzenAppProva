document.addEventListener("DOMContentLoaded", function () {
    abrirLoader();
    carregarDadosTabelaAbastecimento();
});


async function carregarDadosTabelaAbastecimento() {
    const response = await fetch('pagamento/ObterRelatorioPorUsuarioTipos/2');
    const data = await response.json();
    let tr = '';
    var date;
    data.Meses.map(dado => {
        tr += `<tr>
               <td>${dado.NCodMes}</td>
               <td>${dado.CDescricao}</td>
               <td>${dado.Valor}</td>
               </tr>`;

    });
    jQuery('#PagamentoRelatorio > tbody').html(tr);
    let nomeTabela = 'PagamentoRelatorio';
    dataTable(nomeTabela);
    fecharLoader();
}
