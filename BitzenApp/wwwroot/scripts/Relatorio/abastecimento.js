document.addEventListener("DOMContentLoaded", function () {
    abrirLoader();
    carregarDadosTabelaAbastecimento();
});


async function carregarDadosTabelaAbastecimento() {
    const response = await fetch('abastecimento/ObterRelatorioPorUsuarioTipos/1');
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
    jQuery('#AbastecimentosRelatorio > tbody').html(tr);
    let nomeTabela = 'AbastecimentosRelatorio';
    dataTable(nomeTabela);
    fecharLoader();
}
