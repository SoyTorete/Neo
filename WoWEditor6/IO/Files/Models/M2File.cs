﻿using System.Collections.Generic;
using System.IO;
using SharpDX;

namespace WoWEditor6.IO.Files.Models
{
    class TextureInfo
    {
        public int TextureType { get; set; }
        public Graphics.Texture Texture { get; set; }
    }

    abstract class M2File
    {
        public M2Vertex[] Vertices { get; protected set; }
        public List<M2RenderPass> Passes { get; private set; }
        public ushort[] Indices { get; protected set; }

        public BoundingBox BoundingBox { get; protected set; }
        public BoundingSphere BoundingSphere { get; protected set; }

        public TextureInfo[] TextureInfos { get; protected set; }

        public string ModelRoot { get; private set; }

        protected M2File(string path)
        {
            ModelRoot = Path.GetDirectoryName(path) ?? "";
            TextureInfos = new TextureInfo[0];
            Vertices = new M2Vertex[0];
            Passes = new List<M2RenderPass>();
            Indices = new ushort[0];
        }

        public abstract bool Load();
    }
}
