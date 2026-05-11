import { useQuery } from '@tanstack/react-query'
import { produtosApi } from '../api/produtosApi'

function brl(v: number) {
  return v.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' })
}

function StatusBadge({ ativo }: { ativo: boolean }) {
  return ativo
    ? <span className="badge rounded-pill badge-ativo fw-semibold" style={{ fontSize: 11, padding: '4px 10px' }}>Ativo</span>
    : <span className="badge rounded-pill badge-inativo fw-semibold" style={{ fontSize: 11, padding: '4px 10px' }}>Inativo</span>
}

export default function ProdutosPage() {
  const { data: produtos = [], isLoading, isError, error } = useQuery({
    queryKey: ['produtos'],
    queryFn: produtosApi.listar,
  })

  const ativos   = produtos.filter(p => p.ativo).length
  const inativos = produtos.length - ativos

  return (
    <>
      <div className="row g-3 mb-4">
        {[
          { label: 'Total de produtos', value: produtos.length, color: '#212529' },
          { label: 'Ativos',            value: ativos,          color: '#2e7d32' },
          { label: 'Inativos',          value: inativos,        color: '#757575' },
        ].map(m => (
          <div key={m.label} className="col-md-4">
            <div className="amr-metric-card">
              <p className="amr-metric-label">{m.label}</p>
              <p className="amr-metric-value" style={{ color: m.color }}>{m.value}</p>
            </div>
          </div>
        ))}
      </div>

      <div className="amr-table-card">
        <div className="d-flex align-items-center justify-content-between px-3 py-3 border-bottom">
          <span style={{ fontSize: 13, fontWeight: 600, color: '#495057' }}>
            <i className="bi bi-box-seam me-2"></i>Catalogo de produtos
          </span>
        </div>

        {isLoading && (
          <div className="amr-empty">
            <div className="spinner-border spinner-border-sm text-primary mb-2" role="status"></div>
            <span style={{ fontSize: 13 }}>Carregando...</span>
          </div>
        )}

        {isError && (
          <div className="p-3">
            <div className="alert alert-danger d-flex align-items-center gap-2 mb-0" style={{ fontSize: 13 }}>
              <i className="bi bi-exclamation-triangle-fill"></i>
              {(error as Error)?.message ?? 'Erro ao carregar produtos.'}
            </div>
          </div>
        )}

        {!isLoading && !isError && produtos.length === 0 && (
          <div className="amr-empty">
            <i className="bi bi-box-seam"></i>
            <div style={{ fontSize: 14, fontWeight: 500 }}>Nenhum produto cadastrado</div>
          </div>
        )}

        {!isLoading && produtos.length > 0 && (
          <div className="table-responsive">
            <table className="table table-hover table-sm mb-0" style={{ fontSize: 13 }}>
              <thead className="table-light">
                <tr>
                  <th>SKU</th>
                  <th>Nome</th>
                  <th>Descricao</th>
                  <th>Unidade</th>
                  <th className="text-end">Preco Unit.</th>
                  <th className="text-end">Est. Minimo</th>
                  <th>Status</th>
                </tr>
              </thead>
              <tbody>
                {produtos.map(p => (
                  <tr key={p.id}>
                    <td className="font-monospace text-muted" style={{ fontSize: 12 }}>{p.sku}</td>
                    <td className="fw-medium">{p.nome}</td>
                    <td className="text-muted" style={{ maxWidth: 200, overflow: 'hidden', textOverflow: 'ellipsis', whiteSpace: 'nowrap' }}>
                      {p.descricao ?? '—'}
                    </td>
                    <td>{p.unidadeMedida}</td>
                    <td className="text-end">{brl(p.precoUnitario)}</td>
                    <td className="text-end">{p.estoqueMinimo}</td>
                    <td><StatusBadge ativo={p.ativo} /></td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        )}
      </div>
    </>
  )
}
