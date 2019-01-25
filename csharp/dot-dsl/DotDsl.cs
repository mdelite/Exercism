using System.Collections;
using System;
using System.Collections.Generic;

public class Node : IEnumerable, IEquatable<Node>
{
    private string v;

    public Node(string v)
    {
        this.v = v;
    }

    public void Add(string type, string val)
    {
        throw new NotImplementedException();
    }

    public bool Equals(Node other)
    {
        throw new NotImplementedException();
    }

    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }
}

public class Edge : IEnumerable, IEquatable<Edge>
{
    private string v1;
    private string v2;

    public Edge(string v1, string v2)
    {
        this.v1 = v1;
        this.v2 = v2;
    }

    public void Add(string v1, string v2)
    {
        throw new NotImplementedException();
    }

    public bool Equals(Edge other)
    {
        throw new NotImplementedException();
    }

    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }
}

public class Attr : IEnumerable, IEquatable<Attr>
{
    private string v1;
    private string v2;

    public Attr(string v1, string v2)
    {
        this.v1 = v1;
        this.v2 = v2;
    }

    public bool Equals(Attr other)
    {
        throw new NotImplementedException();
    }

    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }
}

public class Graph : IEnumerable
{
    public IEnumerable<Node> Nodes { get; internal set; }
    public IEnumerable<Edge> Edges { get; internal set; }
    public IEnumerable<Attr> Attrs { get; internal set; }

    public void Add(Node Nodes)
    {
        throw new NotImplementedException();
    }

    public void Add(Edge edges)
    {
        throw new NotImplementedException();
    }

    public void Add(string type, string value)
    {
        throw new NotImplementedException();
    }

    public IEnumerator GetEnumerator()
    {
        throw new System.NotImplementedException();
    }
}