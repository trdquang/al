function updateTree(root) {
    const nodes = new vis.DataSet();
    const edges = new vis.DataSet();

    function traverse(node, parent = null) {
        if (!node) return;
        nodes.add({ id: node.Value, label: node.Value.toString() });
        if (parent !== null) {
            edges.add({ from: parent, to: node.Value });
        }
        traverse(node.Left, node.Value);
        traverse(node.Right, node.Value);
    }

    traverse(root);

    const container = document.getElementById('graphContainer');
    const data = { nodes: nodes, edges: edges };
    const options = {
        layout: {
            hierarchical: {
                direction: 'UD',
                nodeSpacing: 100,
                levelSeparation: 100
            }
        },
        nodes: { shape: 'circle', size: 30, color: '#0d6efd' },
        edges: { color: '#999' },
        physics: false
    };
    new vis.Network(container, data, options);
}