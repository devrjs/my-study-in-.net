export interface IPessoa {
  id: number
  nome: string
  idade: number
  email: string
}

export async function getAllPessoas(): Promise<IPessoa[]> {
  const response = await fetch('https://localhost:7025/api/Pessoa')
  const data = await response.json()

  return data
}
