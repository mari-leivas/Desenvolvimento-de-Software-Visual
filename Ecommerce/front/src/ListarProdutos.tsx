//componete 
//- precisa ser uma função 

import { useEffect } from "react";

//- precisa retonar um elemento html pai 
function ListarProdutos(){
    useEffect(() => {
        console.log("o componente foi carregado");
        buscarProdutosAPI();
   
    }, []);
    async function buscarProdutosAPI(){
        try {
            const resposta = await fetch("http://localhost:3000/api/produtos/listar");
            if (!resposta.ok) {
                throw new Error("Erro na requisição" + resposta.statusText);
            }
            const dados = await resposta.json();
            console.table( dados);
        } catch (error) {

            console.error("Erro ao buscar produtos:", error);
        }
    }
    return(
        <><div id="listar-produtos">
            <h1>Listar Produtos</h1>
        </div></>
    );

}
export default ListarProdutos;
