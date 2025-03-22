async function deleteDriver(driverId) {
    if (!confirm("Tem certeza que deseja excluir este motorista?")) {
        return;
    }

    try {
        const response = await fetch(`/Driver/${driverId}`,
            {
                method: 'DELETE'
            });

        if (response.ok) {
            alert("Motorista deletado com sucesso.");
            location.reload(); // Recarrega a página para atualizar a lista
        }
        else {
            alert("Erro ao excluir o motorista.");
        }
    }
    catch (error) {
        console.error("Erro ao excluir:", error);
        alert("Erro ao excluir o motorista.");
    }
}