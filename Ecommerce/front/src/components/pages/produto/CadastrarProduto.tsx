import { useState } from "react";
import Produto from "../../../models/Produto";

function CadastrarProduto() {

  const [nome, setNome] = useState("");

  function enviarProduto(event: any) {
    event.preventDefault();
    submeterProdutoAPI();
  }

  async function submeterProdutoAPI(){
    //Biblioteca AXIOS

    const produto : Produto = {
        nome : nome,
        descricao : "Teste",
        preco : 123456,
        quantidade : 987654
    };

    const resposta = 
        await fetch("http://localhost:5011/api/produto/cadastrar", {
            method : "POST",
            headers : {
                "Content-Type" : "application/json"
            },
            body : JSON.stringify(produto)
        });
  }

  function escreverNome(event: any) {
    setNome(event.target.value);
  }
  return (
    <div>
      <h1>Cadastrar Produto</h1>
      <form onSubmit={enviarProduto}>
        <div>
          <label>Nome:</label>
          <input onChange={escreverNome} type="text" />
        </div>
        <div>
          <label>Descrição:</label>
          <input type="text" />
        </div>
        <div>
          <button type="submit">Cadastrar</button>
        </div>
      </form>
    </div>
  );
}

export default CadastrarProduto;
