import { useQuery, useQueryClient } from '@tanstack/react-query'
import { getAllPessoas, type IPessoa } from '../http/get-all-pessoas'
import { Link } from 'react-router-dom'
import { Delete } from '../http/delete'

export function Home() {
  const queryClient = useQueryClient()

  const { data, isLoading, error } = useQuery({
    queryKey: ['pessoas'],
    queryFn: getAllPessoas,
  })

  async function handleDeletePessoa(id: number) {
    if (confirm('Deseja excluir esta pessoa?')) {
      try {
        await Delete(id)
        await queryClient.invalidateQueries({ queryKey: ['pessoas'] })
      } catch (error) {
        console.error('Erro ao excluir pessoa:', error)
        alert(
          'Ocorreu um erro ao excluir a pessoa. Por favor, tente novamente.'
        )
      }
    }
  }

  if (isLoading) return <div>Carregando...</div>
  if (error) return <div>Ocorreu um erro ao carregar os dados.</div>

  return (
    <div className="flex justify-center">
      <div className="w-[1200px] flex flex-col gap-4">
        <h2 className="text-2xl">Lista de Pessoas</h2>
        <Link className="max-w-fit bg-orange-500 p-1 rounded" to="/create">
          Cadastrar
        </Link>
        <table className="w-1/2 border">
          <thead className="text-left">
            <tr>
              <th>Nome</th>
              <th>Idade</th>
              <th>Email</th>
              <th>Ações</th>
            </tr>
          </thead>
          <tbody>
            {data?.map((pessoa: IPessoa) => (
              <tr key={pessoa.id}>
                <td>{pessoa.nome}</td>
                <td>{pessoa.idade}</td>
                <td>{pessoa.email}</td>
                <td className="justify-end gap-2 flex pr-2">
                  <Link
                    className="bg-green-500 p-0.5 px-1.5 rounded"
                    to={`/details/${pessoa.id}`}
                  >
                    Detalhes
                  </Link>
                  <Link
                    className="bg-blue-500 p-0.5 px-1.5 rounded"
                    to={`/edit/${pessoa.id}`}
                  >
                    Editar
                  </Link>
                  <button
                    className="bg-red-500 p-0.5 px-1.5 rounded"
                    type="button"
                    onClick={() => handleDeletePessoa(pessoa.id)}
                  >
                    Excluir
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  )
}
