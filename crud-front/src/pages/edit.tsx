import { useEffect } from 'react'
import { z } from 'zod'
import { useForm } from 'react-hook-form'
import { zodResolver } from '@hookform/resolvers/zod'
import { useNavigate, useParams } from 'react-router-dom'
import { useQuery } from '@tanstack/react-query'
import { getById } from '../http/get-by-id'
import { edit } from '../http/edit'

const editPessoaSchema = z.object({
  nome: z.string().min(1, 'Nome obrigatório'),
  idade: z.coerce.number().min(1, 'Idade obrigatória'),
  email: z.string().email('Email inválido'),
})

type EditPessoaSchema = z.infer<typeof editPessoaSchema>

export function Edit() {
  const params = useParams()
  const navigate = useNavigate()

  const { data, isLoading } = useQuery({
    queryKey: ['details', params.id],
    queryFn: async () => {
      if (params.id) {
        return await getById(params.id)
      }
    },
  })

  const {
    register,
    handleSubmit,
    formState: { errors },
    setValue,
  } = useForm<EditPessoaSchema>({
    resolver: zodResolver(editPessoaSchema),
  })

  useEffect(() => {
    if (data) {
      setValue('nome', data.nome)
      setValue('idade', data.idade)
      setValue('email', data.email)
    }
  }, [data, setValue])

  async function handleEditPessoa(formData: EditPessoaSchema) {
    try {
      await edit({
        id: params.id as string,
        nome: formData.nome,
        idade: formData.idade,
        email: formData.email,
      })

      navigate('/')
    } catch (error) {
      console.log(error)
    }
  }

  if (isLoading) {
    return <div>Carregando...</div>
  }

  return (
    <div className="flex justify-center">
      <form
        onSubmit={handleSubmit(handleEditPessoa)}
        className="w-[400px] flex flex-col gap-4"
      >
        <h2 className="text-2xl">Editar</h2>
        <span className="flex flex-col">
          <label htmlFor="nome">Nome:</label>
          <input
            className="h-10 bg-gray-800 rounded"
            type="text"
            id="nome"
            {...register('nome')}
          />
          <span className="text-red-500">{errors.nome?.message}</span>
        </span>
        <span className="flex flex-col">
          <label htmlFor="idade">Idade:</label>
          <input
            className="h-10 bg-gray-800 rounded"
            type="number"
            id="idade"
            {...register('idade')}
          />
          <span className="text-red-500">{errors.idade?.message}</span>
        </span>
        <span className="flex flex-col">
          <label htmlFor="email">Email:</label>
          <input
            className="h-10 bg-gray-800 rounded"
            type="email"
            id="email"
            {...register('email')}
          />
          <span className="text-red-500">{errors.email?.message}</span>
        </span>
        <button
          className="max-w-fit h-10 self-center bg-green-500 p-0.5 px-1.5 rounded"
          type="submit"
        >
          Salvar
        </button>
      </form>
    </div>
  )
}
