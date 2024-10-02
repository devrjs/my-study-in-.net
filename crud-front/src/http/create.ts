export interface CreatePessoaRequest {
  nome: string
  email: string
  idade: number
}

export async function create({
  nome,
  email,
  idade,
}: CreatePessoaRequest): Promise<void> {
  const response = await fetch('https://localhost:7025/api/Pessoa', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify({
      nome,
      email,
      idade,
    }),
  })

  if (!response.ok) {
    throw new Error('Error while creating the pessoa')
  }
}
