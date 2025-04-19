window.renderGraph = function (graph, isDirected) {
    var nodes = [];
    var edges = [];
    for (var from in graph) {
        for (var to of graph[from]) {
            edges.push({ from: from, to: to });
            nodes.push({ id: from, label: from });
            nodes.push({ id: to, label: to });
        }
    }

    var container = document.getElementById("graphContainer");
    var data = {
        nodes: new vis.DataSet(nodes),
        edges: new vis.DataSet(edges),
    };
    var options = {
        nodes: { shape: 'dot', size: 20, color: '#0d6efd', font: { color: '#000', size: 16, bold: true } },
        edges: { color: '#999', arrows: isDirected ? { to: { enabled: true } } : { to: { enabled: false } } },
        physics: { enabled: true, stabilization: { iterations: 200 } }
    };
    new vis.Network(container, data
