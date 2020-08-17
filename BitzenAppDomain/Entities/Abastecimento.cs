using BitzenAppDomain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BitzenAppDomain.Entities
{
    public class Abastecimento : EntityBase
    {
        public int NCodAbastecimento { get; private set; }
        public double NKmAbastecimento { get; private set; }
        public double NLitroAbastecimento { get; private set; }
        public double VVlrPago { get; private set; }
        public DateTime DAbastecimento { get; private set; }
        public Posto Posto { get; private set; }
        public Usuario UsuarioInc { get; private set; }
        public TipoCombustivel TipoCombustivel { get; private set; }
        public TipoVeiculo TipoVeiculo { get; private set; }
        public Veiculo Veiculo { get; private set; }


        public Abastecimento()
        {
            Posto = new Posto();
            UsuarioInc = new Usuario();
            TipoVeiculo = new TipoVeiculo();
            TipoCombustivel = new TipoCombustivel();
            Veiculo = new Veiculo();
        }

        #region setters
        public void setVeiculo(Veiculo veiculo)
        {
            Veiculo = veiculo;
        }

        public void setNCodAbastecimento(int nCodAbastecimento)
        {
            NCodAbastecimento = nCodAbastecimento;
        }
        public void setNKmAbastecimento(double nKmAbastecimento)
        {
            NKmAbastecimento = nKmAbastecimento;
        }
        public void setNLitroAbastecimento(double nLitroAbastecimento)
        {
            NLitroAbastecimento = nLitroAbastecimento;
        }
        public void setVVlrPago(double vVlrPago)
        {
            VVlrPago = vVlrPago;
        }
        public void setDAbastecimento(DateTime dAbastecimento)
        {
            DAbastecimento = dAbastecimento;
        }
        public void setPosto(Posto posto)
        {
            Posto = posto;
        }
        public void setUsuarioInc(Usuario usuarioInc)
        {
            UsuarioInc = usuarioInc;
        }
        public void setTipoCombustivel(TipoCombustivel tipoCombustivel)
        {
            TipoCombustivel = tipoCombustivel;
        }
        public void setTipoVeiculo(TipoVeiculo tipoVeiculo)
        {
            TipoVeiculo = tipoVeiculo;
        }
        #endregion
        public override bool EstaConsistente()
        {
            return !ListaErros.Any();
        }
    }
}
