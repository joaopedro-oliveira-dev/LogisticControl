async function deleteAddress(addressId) {
    if (!confirm("Tem certeza que deseja excluir este endereço?")) {
        return;
    }

    try {
        const response = await fetch(`/Address/${addressId}`,
            {
                method: 'DELETE'
            });

        if (response.ok) {
            alert("Endereço deletado com sucesso.");
            location.reload(); // Recarrega a página para atualizar a lista
        }
        else {
            alert("Erro ao excluir endereço.");
        }
    }
    catch (error) {
        console.error("Erro ao excluir:", error);
        alert("Erro ao excluir endereço.");
    }
}