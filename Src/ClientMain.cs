using System.Numerics;
using Raylib_cs;

class ClientMain {

    static Rewrite_W2B w2b;
    static int windowWidth = 960;
    static int windowHeight = 540;

    public static void Main() {


        Raylib.InitWindow(windowWidth, windowHeight, "Raylib C# Client");
        Raylib.SetExitKey(KeyboardKey.KEY_NULL);

        Raylib.SetTargetFPS(15);

        while (!Raylib.WindowShouldClose()) {

            if (Raylib.IsKeyReleased(KeyboardKey.KEY_ESCAPE)) {
                Clear();
            }

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE)) {
                Restart();
            }

            float dt = Raylib.GetFrameTime();
            Update(dt);

            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.GRAY);

            Draw();

            Raylib.EndDrawing();

        }

        Raylib.CloseWindow();

    }

    static void Clear() {
        w2b = null;
        GC.Collect();
    }

    static void Restart() {
        w2b = new Rewrite_W2B(windowWidth,
                              windowHeight,
                              Raylib.GetRandomValue(0, windowWidth - 1),
                              Raylib.GetRandomValue(0, windowHeight - 1),
                              Color.WHITE,
                              Color.BLACK);
    }

    static void Update(float deltaTime) {

        w2b?.Update();

        const float INTERVAL = 0.01f;
        float restTime = deltaTime;
        for (; restTime >= INTERVAL; restTime -= INTERVAL) {
            FixedUpdate(INTERVAL);
        }
        FixedUpdate(restTime);

    }

    static void FixedUpdate(float fixedDeltaTime) {

    }

    static void Draw() {
        w2b?.Draw();
    }

}