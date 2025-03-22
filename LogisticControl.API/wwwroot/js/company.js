async function deleteCompany(companyId)
{
    if (!confirm("Tem certeza que deseja excluir esta empresa?"))
    {
        return;
    }

    try
    {
        const response = await fetch(`/Company/${companyId}`,
        {
            method: 'DELETE' 
        });

        if (response.ok)
        {
            alert("Empresa deletada com sucesso.");
            location.reload(); // Recarrega a página para atualizar a lista
        }
        else
        {
            alert("Erro ao excluir a empresa.");
        }
    }
    catch (error)
    {
        console.error("Erro ao excluir:", error);
        alert("Erro ao excluir a empresa.");
    }
}