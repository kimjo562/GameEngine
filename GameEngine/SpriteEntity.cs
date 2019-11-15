using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using RL = Raylib.Raylib;

namespace GameEngine
{
    class SpriteEntity : Entity
    {
        private Texture2D _texture = new Texture2D();
        private Image _image = new Image();

        public SpriteEntity()
        {

        }

        public float Top
        {   // Wall Displacement and px affect location of enemy entity (px 16 + wall Displace)
            get { return YAbsolute + 0.5f; }
        }

        public float Bottom
        {   // Wall Displacement and px affect location of enemy entity (px 16 + wall Displace)
            get { return YAbsolute + Height + 0.5f; }
        }

        public float Left
        {   // Wall Displacement and px affect location of enemy entity (px 15 + wall Displace)
            get { return XAbsolute + 0.5f; }
        }

        public float Right
        {   // Wall Displacement and px affect location of enemy entity (px 15 + wall Displace)
            get { return XAbsolute + Width + 0.5f; }
        }

        public float Width
        {
            get { return _texture.width / Game.UnitSize.x; }
        }

        public float Height
        {
            get { return _texture.height / Game.UnitSize.y; }
        }

        public Texture2D Texture
        {
            get { return _texture; }
        }

        public void Load(string path)
        {
            _image = RL.LoadImage(path);
            _texture = RL.LoadTextureFromImage(_image);
            X = -Width / 2;
            Y = -Height / 2;
        }
    }
}
