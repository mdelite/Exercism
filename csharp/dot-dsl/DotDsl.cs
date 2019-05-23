using System;
using System.Collections;
using System.Collections.Generic;

public class Node : HasAttrs
{
    public string Name { set; get; }
    public Node(string v)
    {
        this.Name = v;
    }
}

public class Edge : HasAttrs
{
    public Node Start { get; protected set; }
    public Node End { get; protected set; }

    public Edge(string start, string end)
    {
        this.Start = new Node(start);
        this.End = new Node(end);
    }
}

public class Attr : IEnumerable<string>
{
    public readonly string Key;
    public readonly string Value;

    public Attr(string key, string val)
    {
        Key = key;
        Value = val;
    }

    IEnumerator<string> IEnumerable<string>.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}

public class Graph : HasAttrs
{
    public HashSet<Node> Nodes { set; get; }
    public HashSet<Edge> Edges { set; get; }

    public Graph()
    {
        Nodes = new HashSet<Node>();
        Edges = new HashSet<Edge>();
    }
    public void Add(Node node) => this.Nodes.Add(node);
    public void Add(Edge edge) => this.Edges.Add(edge);

}

public abstract class HasAttrs : IEnumerable<Attr>
{
    public HashSet<Attr> Attrs { get; protected set; }
    public HasAttrs() => Attrs = new HashSet<Attr>();

    public IEnumerator<Attr> GetEnumerator() => Attrs.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public void Add(string key, string value) => Attrs.Add(new Attr(key, value));
}