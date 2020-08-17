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


        public void PrepararDadosParaInserir(string NKmAbastecimento,string NLitroAbastecimento, string VVlrPago, string DAbastecimento, string Posto, string UsuarioInc, string TipoCombustivel,string TipoVeiculo, string Veiculo)
        {
            validarNKmAbastecimento(NKmAbastecimento);
            validarNLitroAbastecimento(NLitroAbastecimento);
            validarVVlrPago(VVlrPago);
            validarDAbastecimento(DAbastecimento);
            validarPosto(Posto);
            validarUsuarioInc(UsuarioInc);
            validarTipoCombustivel(TipoCombustivel);
            validarTipoVeiculo(TipoVeiculo);
            validarVeiculo(Veiculo);
        }

        public void PrepararDadosParaAtualizar(string NCodAbastecimento,string NKmAbastecimento, string NLitroAbastecimento, string VVlrPago, string DAbastecimento, string Posto, string UsuarioInc, string TipoCombustivel, string TipoVeiculo, string Veiculo)
        {
            validarNCodAbastecimento(NCodAbastecimento);
            validarNKmAbastecimento(NKmAbastecimento);
            validarNLitroAbastecimento(NLitroAbastecimento);
            validarVVlrPago(VVlrPago);
            validarDAbastecimento(DAbastecimento);
            validarPosto(Posto);
            validarTipoCombustivel(TipoCombustivel);
            validarTipoVeiculo(TipoVeiculo);
            validarVeiculo(Veiculo);
        }


        #region Validações
        private void validarNCodAbastecimento(string nCodAbastecimento)
        {
            int auxnCodAbastecimento;
            if (int.TryParse(nCodAbastecimento, out auxnCodAbastecimento))
                NCodAbastecimento = auxnCodAbastecimento;
            else
                ListaErros.Add("O código do abastecimento está inválido");
        }
        private void validarNKmAbastecimento(string nKmAbastecimento)
        {
            double auxnKmAbastecimento;
            if (double.TryParse(nKmAbastecimento, out auxnKmAbastecimento))
                NKmAbastecimento = auxnKmAbastecimento;
            else
                ListaErros.Add("O KM abastecido está incorreto!");
        }
        private void validarNLitroAbastecimento(string nLitroAbastecimento)
        {
            double auxnLitroAbastecimento;
            if (double.TryParse(nLitroAbastecimento, out auxnLitroAbastecimento))
                NLitroAbastecimento = auxnLitroAbastecimento;
            else
                ListaErros.Add("O quantidade de litros abastecidos está incorreto!");
        }
        private void validarVVlrPago(string vVlrPago)
        {
            double auxvVlrPago;
            if (double.TryParse(vVlrPago, out auxvVlrPago))
                VVlrPago = auxvVlrPago;
            else
                ListaErros.Add("O valor está incorreto!");
        }

        private void validarDAbastecimento(string dAbastecimento)
        {
            DateTime auxdt;
            if (DateTime.TryParse(dAbastecimento, out auxdt))
                DAbastecimento = auxdt;
            else
                ListaErros.Add("Data de abastecimento incorreta!");

        }
        private void validarPosto(string posto)
        {
            int auxnPosto;
            if (int.TryParse(posto, out auxnPosto))
                Posto.setNCodPosto(auxnPosto);
            else
                ListaErros.Add("O código do posto está incorreto");

        }
        private void validarUsuarioInc(string usuarioInc)
        {
            int auxnusuarioInc;
            if (int.TryParse(usuarioInc, out auxnusuarioInc))
                UsuarioInc.setNCodUsuario(auxnusuarioInc);
            else
                ListaErros.Add("O código do usuário não foi encontrado");

        }
        private void validarTipoCombustivel(string tipoCombustivel)
        {
            int auxtipoCombustivel;
            if (int.TryParse(tipoCombustivel, out auxtipoCombustivel))
                TipoCombustivel.setNCodCombustivel(auxtipoCombustivel);
            else
                ListaErros.Add("O tipo de combustível está incorreto");

        }
        private void validarTipoVeiculo(string tipoVeiculo)
        {
            int auxtipoVeiculo;
            if (int.TryParse(tipoVeiculo, out auxtipoVeiculo))
                TipoVeiculo.setNCodTipoVeiculo(auxtipoVeiculo);
            else
                ListaErros.Add("O tipo de veículo está incorreto!");

        }
        private void validarVeiculo(string veiculo)
        {
            int auxveiculo;
            if (int.TryParse(veiculo, out auxveiculo))
                Veiculo.setNCodVeiculo(auxveiculo);
            else
                ListaErros.Add("Veículo incorreto!");

        }


        #endregion

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
