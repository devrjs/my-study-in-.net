export interface EditPessoaRequest {
  id: string
  nome: string
  email: string
  idade: number
}

export async function edit({
  id,
  nome,
  email,
  idade,
}: EditPessoaRequest): Promise<void> {
  const response = await fetch(`https://localhost:7025/api/Pessoa/${id}`, {
    method: 'PUT',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify({
      id,
      nome,
      email,
      idade,
    }),
  })

  if (!response.ok) {
    throw new Error('Error while editing the pessoa')
  }
}
