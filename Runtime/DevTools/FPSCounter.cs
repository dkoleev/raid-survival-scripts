using UnityEngine;

namespace RaidSurvival.Runtime.DevTools {
    public class FPSCounter : MonoBehaviour {
        private const float UpdateInterval = 0.5f;
        private float _accumulation;
        private int _frames;
        private float _timeLeft;
        private float _fps;

        private GUIStyle _textStyle;

        private void Start() {
            _timeLeft = UpdateInterval;

            _textStyle = new GUIStyle {
                fontSize = 42,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleLeft,
                normal = { textColor = Color.white }
            };
        }

        private void Update()
        {
            _timeLeft -= Time.deltaTime;
            _accumulation += Time.timeScale / Time.deltaTime;
            ++_frames;

            if (_timeLeft <= 0.0f)
            {
                _fps = _accumulation / _frames;
                _timeLeft = UpdateInterval;
                _accumulation = 0.0f;
                _frames = 0;
            }
        }

        private void OnGUI() {
            _textStyle.normal.textColor = _fps switch {
                >= 50f => Color.green,
                >= 30f => Color.yellow,
                _      => Color.red
            };

            GUI.Label(new Rect(5, 5, 200, 50), $"{_fps:F2} FPS", _textStyle);
        }
    }
}
