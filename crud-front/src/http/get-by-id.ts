import type { IPessoa } from './get-all-pessoas'

export async function getById(id: string): Promise<IPessoa> {
  const response = await fetch(`https://localhost:7025/api/Pessoa/${id}`)
  const data = await response.json()

  return data
}
