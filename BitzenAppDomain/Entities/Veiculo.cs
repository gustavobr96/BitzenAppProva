using BitzenAppDomain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BitzenAppDomain.Entities
{
    public class Veiculo : EntityBase
    {
        public int NCodVeiculo { get; private set; }
        public Marca Marca { get; private set; }
        public Modelo Modelo { get; private set; }
        public int DAno { get; private set; }
        public string CPlaca { get; private set; }
        public TipoVeiculo TipoVeiculo { get; private set; }
        public TipoCombustivel TipoCombustivel { get; private set; }
        public int CQuilometragem { get; private set; }
        public Usuario UsuarioResp { get; private set; }


        public Veiculo()
        {
            Marca = new Marca();
            Modelo = new Modelo();
            TipoVeiculo = new TipoVeiculo();
            TipoCombustivel = new TipoCombustivel();
            UsuarioResp = new Usuario();
        }

        public void PrepararDadosParaInserir(string CMarca, string CModelo, string CAno, string CPlaca, string CTipoVeiculo, string CTipoCombustivel, string CCquilometragem, string CUsuario)
        {

            validarMarca(CMarca);
            validarModelo(CModelo);
            validarCAno(CAno);
            validarCPlaca(CPlaca);
            validarCTipoVeiculo(CTipoVeiculo);
            validarCTipoCombustivel(CTipoCombustivel);
            validarCCquilometragem(CCquilometragem);
            validarCUsuario(CUsuario);

        }

        #region validações
        private void validarMarca(string cMarca)
        {
            if (string.IsNullOrEmpty(cMarca))
                ListaErros.Add("A marca não pode ser vazia.");
            else
            {
                Marca.setNCodMarca(int.Parse(cMarca));
            }
        }
        private void validarModelo(string cModelo)
        {

            if (string.IsNullOrEmpty(cModelo))
                ListaErros.Add("O Modelo não pode ser vazia.");
            else
            {
                Modelo.setNCodModelo(int.Parse(cModelo));
            }

        }
        private void validarCAno(string cAno)
        {
            int auxAno;
            if (int.TryParse(cAno, out auxAno))
                DAno = auxAno;
            else
                ListaErros.Add("O ano é obrigatório");
        }
        private void validarCPlaca(string cPlaca)
        {
            if (string.IsNullOrEmpty(cPlaca))
                ListaErros.Add("A Placa não pode ser vazia.");
            else
            {
                CPlaca = cPlaca;
            }
        }
        private void validarCTipoVeiculo(string cTipoVeiculo)
        {

            if (string.IsNullOrEmpty(cTipoVeiculo))
                ListaErros.Add("O Tipo de veiculo não pode ser vazio.");
            else
            {
                TipoVeiculo.setNCodTipoVeiculo(int.Parse(cTipoVeiculo));
            }

        }
        private void validarCTipoCombustivel(string cTipoCombustivel)
        {
            if (string.IsNullOrEmpty(cTipoCombustivel))
                ListaErros.Add("O Tipo de combustivel não pode ser vazio.");
            else
            {
                TipoCombustivel.setNCodCombustivel(int.Parse(cTipoCombustivel));
            }
        }
        private void validarCCquilometragem(string cQuilometragem)
        {
            int auxcQuilometragem;
            if (int.TryParse(cQuilometragem, out auxcQuilometragem))
                CQuilometragem = auxcQuilometragem;
            else
                ListaErros.Add("A quilometragem é obrigatória");
        }
        private void validarCUsuario(string cUsuario)
        {
            if (string.IsNullOrEmpty(cUsuario))
                ListaErros.Add("Erro ao utilizar o usuário logado, por favor faça o login novamete!.");
            else
            {
                UsuarioResp.setNCodUsuario(int.Parse(cUsuario));
            }
        }

        #endregion

        #region Setters
        public void setNCodVeiculo(int nCodVeiculo)
        {
            NCodVeiculo = nCodVeiculo;
        }
        public void setMarca(Marca marca)
        {
            Marca = marca;
        }
        public void setModelo(Modelo modelo)
        {
            Modelo = modelo;
        }
        public void setDAno(int dAno)
        {
            DAno = dAno;
        }
        public void setCPlaca(string cPlaca)
        {
            CPlaca = cPlaca;
        }
        public void setTipoVeiculo(TipoVeiculo tipoVeiculo)
        {
            TipoVeiculo = tipoVeiculo;
        }
        public void setTipoCombustivel(TipoCombustivel tipoCombustivel)
        {
            TipoCombustivel = tipoCombustivel;
        }
        public void setCQuilometragem(int cQuilometragem)
        {
            CQuilometragem = cQuilometragem;
        }
        public void setUsuarioResp(Usuario usuarioResp)
        {
            UsuarioResp = usuarioResp;
        }

        public override bool EstaConsistente()
        {
            return !ListaErros.Any();
        }
        #endregion

    }
}
