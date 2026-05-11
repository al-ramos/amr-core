import { api } from './axiosInstance'

export interface ProdutoDto {
  id: number
  sku: string
  nome: string
  descricao?: string
  precoUnitario: number
  estoqueMinimo: number
  unidadeMedida: string
  ativo: boolean
}

export interface CriarProdutoPayload {
  sku: string
  nome: string
  descricao?: string
  precoUnitario: number
  estoqueMinimo: number
  unidadeMedidaId: number
  empresaId: number
}

export const produtosApi = {
  listar: () => api.get<ProdutoDto[]>('/Produto').then(r => r.data),
  criar:  (payload: CriarProdutoPayload) => api.post<ProdutoDto>('/Produto', payload).then(r => r.data),
}
