export async function Delete(id: number) {
  const response = await fetch(`https://localhost:7025/api/Pessoa/${id}`, {
    method: 'DELETE',
  })

  if (!response.ok) {
    throw new Error('Error while creating the pessoa')
  }
}
