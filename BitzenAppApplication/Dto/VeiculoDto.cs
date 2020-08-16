using BitzenAppDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitzenAppApplication.Dto
{
    public class VeiculoDto
    {
        public string NCodVeiculo { get;  set; }
        public string CMarca { get; set; }
        public string NCodMarca { get;  set; }
        public string CModelo { get; set; }
        public string NCodModelo { get;  set; }
        public string DAno { get; set; }
        public string CPlaca { get; set; }
        public string CTipoVeiculo { get; set; }
        public string NCodTipoVeiculo { get; set; }
        public string CTipoCombustivel { get;  set; }
        public string NCodTipoCombustivel { get;  set; }
        public string CQuilometragem { get;  set; }
        public string CUsuarioResp { get;  set; }
        public string NCodUsuarioResp { get;  set; }

        public static explicit operator VeiculoDto(Veiculo v)
        {
            return new VeiculoDto
            {
                NCodVeiculo = v.NCodVeiculo.ToString(),
                CMarca = v.Marca.CDescricao,
                NCodMarca = v.Marca.NCodMarca.ToString(),
                CModelo = v.Modelo.CDescricao,
                NCodModelo = v.Modelo.NCodModelo.ToString(),
                DAno = v.DAno.ToString(),
                CPlaca = v.CPlaca,
                CTipoVeiculo = v.TipoVeiculo.CDescricao,
                NCodTipoVeiculo = v.TipoVeiculo.NCodTipoVeiculo.ToString(),
                CTipoCombustivel = v.TipoCombustivel.CDescricao,
                NCodTipoCombustivel = v.TipoCombustivel.NCodCombustivel.ToString(),
                CQuilometragem = v.CQuilometragem.ToString(),
                CUsuarioResp = v.UsuarioResp.CNome,
                NCodUsuarioResp = v.UsuarioResp.NCodUsuario.ToString()

            };
        }



    }
}
