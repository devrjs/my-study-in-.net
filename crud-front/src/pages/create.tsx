import { z } from 'zod'
import { create } from '../http/create'
import { useForm } from 'react-hook-form'
import { zodResolver } from '@hookform/resolvers/zod'
import { useNavigate } from 'react-router-dom'

const createPessoaSchema = z.object({
  nome: z.string().min(1, 'Nome obrigatório'),
  idade: z.coerce.number().min(1, 'Idade obrigatória'),
  email: z.string().email('Email inválido'),
})

type CreatePessoaSchema = z.infer<typeof createPessoaSchema>

export function Create() {
  const navigate = useNavigate()
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<CreatePessoaSchema>({
    resolver: zodResolver(createPessoaSchema),
  })

  async function handleCreatePessoa(data: CreatePessoaSchema) {
    try {
      await create({
        nome: data.nome,
        idade: data.idade,
        email: data.email,
      })

      navigate('/')
    } catch (error) {
      console.log(error)
    }
  }

  return (
    <div className="flex justify-center">
      <form
        onSubmit={handleSubmit(handleCreatePessoa)}
        className="w-[400px] flex flex-col gap-4"
      >
        <h2 className="text-2xl">Cadastro</h2>
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
          onClick={() => {}}
        >
          Cadastrar
        </button>
      </form>
    </div>
  )
}
