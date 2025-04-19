let network;
let nodes = new vis.DataSet();
let edges = new vis.DataSet();
let graph = {};
let distances = {};
let previous = {};

// Hàm phân tích các cạnh và tạo đồ thị
function parseEdges(input, graphType) {
    const lines = input.trim().split('\n');
    graph = {};
    nodes.clear();
    edges.clear();

    for (let line of lines) {
        const parts = line.trim().split(' ');
        if (parts.length < 3) continue;

        const [from, to, weight] = parts;
        const w = parseInt(weight);
        if (!graph[from]) graph[from] = [];
        if (!graph[to]) graph[to] = [];

        if (graphType === "undirected") {
            graph[from].push({ to, weight: w });
            graph[to].push({ to: from, weight: w });
            edges.update([
                { from, to, label: weight.toString() },
                { from: to, to: from, label: weight.toString() }
            ]);
        } else {
            graph[from].push({ to, weight: w });
            edges.update({ from, to, label: weight.toString() });
        }

        nodes.update([
            { id: from, label: from },
            { id: to, label: to }
        ]);
    }
}

// Hàm vẽ đồ thị
function renderGraph() {
    const container = document.getElementById("graphContainer");
    const data = { nodes: nodes, edges: edges };
    const options = {
        nodes: {
            shape: 'dot',
            size: 20,
            color: '#0d6efd',
            font: {
                color: '#000',
                size: 16,
                bold: true
            }
        },
        edges: {
            arrows: { to: { enabled: false } },
            color: '#999'
        },
        physics: { enabled: true, stabilization: { iterations: 200 } }
    };
    network = new vis.Network(container, data, options);
}

// Thuật toán Dijkstra
function dijkstra(start) {
    distances = {};
    previous = {};
    const nodesQueue = [];

    for (let node in graph) {
        distances[node] = Infinity;
        previous[node] = null;
        nodesQueue.push(node);
    }
    distances[start] = 0;

    let steps = [];
    while (nodesQueue.length > 0) {
        nodesQueue.sort((a, b) => distances[a] - distances[b]);
        const node = nodesQueue.shift();

        if (distances[node] === Infinity) break;

        for (let neighbor of graph[node]) {
            const alt = distances[node] + neighbor.weight;
            if (alt < distances[neighbor.to]) {
                distances[neighbor.to] = alt;
                previous[neighbor.to] = node;
            }
        }

        steps.push(`Đỉnh ${node}: Khoảng cách - ${distances[node]}`);
    }

    function getPath(start, end) {
        let path = [];
        let current = end;
        while (current !== start) {
            if (current === null) break;
            path.push(current);
            current = previous[current];
        }
        path.push(start);
        return path.reverse();
    }

    let pathResults = {};
    for (let node in graph) {
        pathResults[node] = getPath(start, node).join(' → ');
    }

    return { steps, pathResults };
}

// Thuật toán Bellman-Ford
function bellmanFord(start) {
    distances = {};
    previous = {};
    const nodesQueue = [];

    for (let node in graph) {
        distances[node] = Infinity;
        previous[node] = null;
        nodesQueue.push(node);
    }
    distances[start] = 0;

    let steps = [];
    for (let i = 0; i < nodesQueue.length - 1; i++) {
        for (let node in graph) {
            for (let neighbor of graph[node]) {
                const alt = distances[node] + neighbor.weight;
                if (alt < distances[neighbor.to]) {
                    distances[neighbor.to] = alt;
                    previous[neighbor.to] = node;
                }
            }
        }

        steps.push(`Đỉnh ${i + 1}: Khoảng cách - ${JSON.stringify(distances)}`);
    }

    function getPath(start, end) {
        let path = [];
        let current = end;
        while (current !== start) {
            if (current === null) break;
            path.push(current);
            current = previous[current];
        }
        path.push(start);
        return path.reverse();
    }

    let pathResults = {};
    for (let node in graph) {
        pathResults[node] = getPath(start, node).join(' → ');
    }

    return { steps, pathResults };
}

// Hàm chạy thuật toán và cập nhật giao diện
async function buildAndRunAlgorithm(edgeInput, startNode, algorithm, graphType) {
    parseEdges(edgeInput, graphType);
    renderGraph();

    let output = '';
    let steps, pathResults;

    if (algorithm === "dijkstra") {
        const result = dijkstra(startNode);
        steps = result.steps;
        pathResults = result.pathResults;

        output += `Quá trình thuật toán Dijkstra:\n`;
        output += steps.join('\n') + '\n\n';

        output += `Kết quả đường đi từ ${startNode} đến các đỉnh:\n`;
        for (let end in pathResults) {
            output += `Đường đi từ ${startNode} đến ${end}: ${pathResults[end]}\n`;
        }

        // Cập nhật quá trình trên đồ thị
        for (let step of steps) {
            await new Promise(resolve => setTimeout(resolve, 1000)); // Dừng một chút để thấy quá trình
            let node = step.split(':')[0].split(' ')[1];
            let edgeColor = '#28a745'; // Màu sắc khi được duyệt

            // Thay đổi màu sắc đỉnh đang duyệt
            nodes.update([{ id: node, color: { background: '#ff5733' } }]);

            // Tô màu các cạnh đang được duyệt
            for (let neighbor of graph[node]) {
                edges.update([{ from: node, to: neighbor.to, color: { color: edgeColor } }]);
            }

            network.redraw();
        }
    } else if (algorithm === "bellman-ford") {
        const result = bellmanFord(startNode);
        steps = result.steps;
        pathResults = result.pathResults;

        output += `Quá trình thuật toán Bellman-Ford:\n`;
        output += steps.join('\n') + '\n\n';

        output += `Kết quả đường đi từ ${startNode} đến các đỉnh:\n`;
        for (let end in pathResults) {
            output += `Đường đi từ ${startNode} đến ${end}: ${pathResults[end]}\n`;
        }

        // Cập nhật quá trình trên đồ thị
        for (let step of steps) {
            await new Promise(resolve => setTimeout(resolve, 1000)); // Dừng một chút để thấy quá trình
            let node = step.split(':')[0].split(' ')[1];
            let edgeColor = '#28a745'; // Màu sắc khi được duyệt

            // Thay đổi màu sắc đỉnh đang duyệt
            nodes.update([{ id: node, color: { background: '#ff5733' } }]);

            // Tô màu các cạnh đang được duyệt
            for (let neighbor of graph[node]) {
                edges.update([{ from: node, to: neighbor.to, color: { color: edgeColor } }]);
            }

            network.redraw();
        }
    }

    // Cập nhật kết quả trên giao diện
    const algorithmOutputElement = document.getElementById("algorithmOutput");
    algorithmOutputElement.textContent = output;
}
