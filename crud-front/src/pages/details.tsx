import { useQuery } from '@tanstack/react-query'
import { useParams } from 'react-router-dom'
import { getById } from '../http/get-by-id'

export function Details() {
  const params = useParams()

  const { data } = useQuery({
    queryKey: ['details', params.id],
    queryFn: async () => {
      if (params.id) {
        return await getById(params.id)
      }
    },
  })

  return (
    <div className="flex justify-center">
      <div className="w-[1200px] flex flex-col gap-4">
        <h2 className="text-2xl">Detalhes</h2>
        <span>Nome: {data?.nome}</span>
        <span>Idade: {data?.idade}</span>
        <span>Email: {data?.email}</span>
      </div>
    </div>
  )
}
